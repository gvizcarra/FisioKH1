using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace FisioKH
{
    public partial class FisioKHCalendar
    {
        private sealed class EventPanel : Panel
        {
            public Color AccentColor { get; set; } = Color.DeepSkyBlue;
            public Color BaseFill { get; set; } = Color.LightBlue;
            public bool Hovered { get; private set; }

            public int CornerRadius { get; set; } = 6;
            public int StripeWidth { get; set; } = 5;

            public EventPanel()
            {
                DoubleBuffered = true;
                SetStyle(ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.UserPaint |
                         ControlStyles.ResizeRedraw, true);

                MouseEnter += (s, e) => { Hovered = true; Invalidate(); BringToFront(); };
                MouseLeave += (s, e) => { Hovered = false; Invalidate(); };
                MouseDown += (s, e) => BringToFront();
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                var rect = new Rectangle(0, 0, Width - 1, Height - 1);

                DrawShadow(g, rect, CornerRadius);

                var fill = Hovered ? ControlPaint.Light(AccentColor, 0.45f) : BaseFill;
                using (var path = RoundedRect(rect, CornerRadius))
                using (var b = new SolidBrush(fill))
                    g.FillPath(b, path);

                if (Hovered)
                {
                    using (var path = RoundedRect(rect, CornerRadius))
                    using (var pen = new Pen(Color.FromArgb(160, AccentColor), 1f))
                        g.DrawPath(pen, path);
                }

                // left stripe
                using (var sb = new SolidBrush(AccentColor))
                    g.FillRectangle(sb, 0, 0, StripeWidth, Height);

                base.OnPaint(e);
            }

            private static GraphicsPath RoundedRect(Rectangle r, int radius)
            {
                int d = radius * 2;
                var path = new GraphicsPath();
                path.AddArc(r.X, r.Y, d, d, 180, 90);
                path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
                path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
                path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
                path.CloseFigure();
                return path;
            }

            private static void DrawShadow(Graphics g, Rectangle rect, int radius)
            {
                // tiny “blur” using 3 translucent passes
                for (int i = 3; i >= 1; i--)
                {
                    int alpha = 16 / i; // subtle
                    var shadowRect = new Rectangle(rect.X + i, rect.Y + i, rect.Width, rect.Height);
                    using (var path = RoundedRect(shadowRect, radius))
                    using (var b = new SolidBrush(Color.FromArgb(alpha, 0, 0, 0)))
                        g.FillPath(b, path);
                }
            }
        }

        private readonly ToolTip _eventTip = new ToolTip
        {
            AutoPopDelay = 5000,
            InitialDelay = 400,
            ReshowDelay = 200,
            ShowAlways = true
        };

        // Creates the visual event card used in Month/Week/Day.
        private Panel CreateEventPanel(CalendarEventKH ev, Size size, Point loc)
        {
            var p = new EventPanel
            {
                Size = size,
                Location = loc,
                AccentColor = ev.Color,
                BaseFill = GetSoftColor(ev.Color),
                BorderStyle = BorderStyle.None,
                Cursor = Cursors.Hand,

                // leave room on the right for icons
                Padding = new Padding(5 + 6, 4, 26, 4) // stripe + text padding + icons space
            };

            // clip children into rounded shape
            p.SizeChanged += (s, e) =>
            {
                var gp = new GraphicsPath();
                int r = p.CornerRadius;
                gp.AddArc(0, 0, r, r, 180, 90);
                gp.AddArc(p.Width - r, 0, r, r, 270, 90);
                gp.AddArc(p.Width - r, p.Height - r, r, r, 0, 90);
                gp.AddArc(0, p.Height - r, r, r, 90, 90);
                gp.CloseAllFigures();
                p.Region = new Region(gp);
            };

            var title = new Label
            {
                Text = ev.Title + " - " + (ev.NombreFisioterapeuta ?? ""),
                Dock = DockStyle.Top,
                Height = 16,
                Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                AutoEllipsis = true
            };

            var time = new Label
            {
                Text = $"{ev.Start:h:mm tt} - {ev.End:h:mm tt}",
                Dock = DockStyle.Top,
                Height = 14,
                Font = new Font("Segoe UI", 7.5f),
                ForeColor = Color.DimGray,
                BackColor = Color.Transparent,
                AutoEllipsis = true,
                Visible = (size.Height >= 26)
            };

            // Add labels (keep your choice: time hidden for month rows)
            // p.Controls.Add(time);
            p.Controls.Add(title);

            // -------------------------
            // FontAwesome icons (top-right)
            // -------------------------
            int iconSize = 14;
            int padRight = 6;
            int top = 4;

            int x = p.Width - (iconSize + padRight);
            void place(Control c, int xx)
            {
                c.Location = new Point(xx, top);
                c.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                c.BackColor = Color.Transparent;
                c.Cursor = Cursors.Hand;
                p.Controls.Add(c);
                c.BringToFront();
            }

            // Keep icon positions correct on resize
            p.SizeChanged += (s, e) =>
            {
                // reflow icons (walk controls from right)
                int xx = p.Width - (iconSize + padRight);
                foreach (Control c in p.Controls.OfType<IconPictureBox>())
                {
                    c.Location = new Point(xx, top);
                    xx -= (iconSize + 4);
                }
            };

            // Add icons in a stable order: DB then Done
            if (ev.HasDbMatch)
            {
                var dbIcon = new IconPictureBox
                {
                    IconChar = IconChar.Database,
                    IconColor = Color.DarkGreen,
                    IconSize = iconSize,
                    Size = new Size(iconSize, iconSize),
                    TabStop = false
                };
                _eventTip.SetToolTip(dbIcon, $"En BD (CitaID: {ev.CitaID})");
                place(dbIcon, x);
                x -= (iconSize + 4);

                // click should behave like the card
                dbIcon.Click += (s, e) => EventClick?.Invoke(this, ev);
                dbIcon.MouseEnter += (s, e) => p.BringToFront();
                dbIcon.MouseDown += (s, e) => p.BringToFront();
            }

            if (ev.Realizada == true)
            {
                var doneIcon = new IconPictureBox
                {
                    IconChar = IconChar.CheckCircle,
                    IconColor = Color.SeaGreen,
                    IconSize = iconSize,
                    Size = new Size(iconSize, iconSize),
                    TabStop = false
                };
                _eventTip.SetToolTip(doneIcon, "Cita realizada");
                place(doneIcon, x);
                x -= (iconSize + 4);

                doneIcon.Click += (s, e) => EventClick?.Invoke(this, ev);
                doneIcon.MouseEnter += (s, e) => p.BringToFront();
                doneIcon.MouseDown += (s, e) => p.BringToFront();
            }

            // overlap friendliness: interacting with labels brings card forward too
            title.MouseEnter += (s, e) => p.BringToFront();
            time.MouseEnter += (s, e) => p.BringToFront();
            title.MouseDown += (s, e) => p.BringToFront();
            time.MouseDown += (s, e) => p.BringToFront();

            // click mapping
            p.Click += (s, e) => EventClick?.Invoke(this, ev);
            title.Click += (s, e) => EventClick?.Invoke(this, ev);
            time.Click += (s, e) => EventClick?.Invoke(this, ev);

            return p;
        }
    }
}

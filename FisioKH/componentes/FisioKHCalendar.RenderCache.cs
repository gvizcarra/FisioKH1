using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FisioKH
{
    public partial class FisioKHCalendar
    {
        // ---------- Render cache (controls) ----------
        private readonly Dictionary<string, List<Control>> _renderCache = new Dictionary<string, List<Control>>();
        private readonly object _renderCacheLock = new object();

        // Invalidate cache when data changes
        private int _eventsVersion = 0;

        // Debounce resize to avoid constant rebuild flicker
        private Timer _resizeDebounce;

        private void InitRenderCache()
        {
            _resizeDebounce = new Timer { Interval = 120 };
            _resizeDebounce.Tick += (s, e) =>
            {
                _resizeDebounce.Stop();
                RefreshCurrentView(useCache: true);
            };

            // NOTE: if you already have a Resize handler, remove it and use this one
            this.Resize += (s, e) =>
            {
                _resizeDebounce.Stop();
                _resizeDebounce.Start();
            };
        }

        private void ClearRenderCache()
        {
            lock (_renderCacheLock)
                _renderCache.Clear();
        }

        private string CacheKey_Month()
            => $"M|{CurrentDate:yyyyMM}|{panelMonth.ClientSize.Width}x{panelMonth.ClientSize.Height}|v{_eventsVersion}";

        private string CacheKey_Week()
        {
            var start = CurrentDate.AddDays(-(int)CurrentDate.DayOfWeek).Date;
            return $"W|{start:yyyyMMdd}|{panelWeek.ClientSize.Width}x{panelWeek.ClientSize.Height}|v{_eventsVersion}";
        }

        private string CacheKey_Day()
            => $"D|{CurrentDate:yyyyMMdd}|{panelDay.ClientSize.Width}x{panelDay.ClientSize.Height}|v{_eventsVersion}";

        private void RenderCached(Panel target, string key, Action renderAction, bool useCache)
        {
            if (useCache)
            {
                lock (_renderCacheLock)
                {
                    if (_renderCache.TryGetValue(key, out var cached) && cached != null && cached.Count > 0)
                    {
                        target.SuspendLayout();
                        try
                        {
                            target.Controls.Clear();
                            // Re-add SAME instances (fast, no flicker)
                            foreach (var c in cached)
                                target.Controls.Add(c);
                        }
                        finally
                        {
                            target.ResumeLayout(true);
                        }
                        return;
                    }
                }
            }

            // Fresh render
            target.SuspendLayout();
            try
            {
                target.Controls.Clear();
                renderAction();
            }
            finally
            {
                target.ResumeLayout(true);
            }

            // Save to cache
            lock (_renderCacheLock)
            {
                _renderCache[key] = target.Controls.Cast<Control>().ToList();
                PruneRenderCache_NoLock(maxEntries: 12);
            }
        }

        private void PruneRenderCache_NoLock(int maxEntries)
        {
            if (_renderCache.Count <= maxEntries) return;

            // simple prune: remove oldest inserted key
            var firstKey = _renderCache.Keys.FirstOrDefault();
            if (firstKey != null)
                _renderCache.Remove(firstKey);
        }
    }
}

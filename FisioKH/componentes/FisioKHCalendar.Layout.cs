using System;
using System.Collections.Generic;
using System.Linq;

namespace FisioKH
{
    public partial class FisioKHCalendar
    {
        // Shared overlap constants used in Day + Week
        private const int OverlapGap = 4;
        private const int OuterPad = 2;
        private const int MinEventWidth = 80;

        // SlotIndex chooses a column for each overlapping group.
        // SlotCount = how many overlap that time window -> used to divide width.
        private List<EventLayoutInfo> BuildLayoutForDate(DateTime day)
        {
            var list = Events
                .Where(e => e.Start.Date == day.Date)
                .OrderBy(e => e.Start)
                .ThenBy(e => e.End)
                .ToList();

            var result = new List<EventLayoutInfo>();

            foreach (var ev in list)
            {
                int slot = 0;

                // find first free slot among already placed events that overlap
                while (result.Any(r =>
                       r.SlotIndex == slot &&
                       r.Event.End > ev.Start &&
                       r.Event.Start < ev.End))
                {
                    slot++;
                }

                result.Add(new EventLayoutInfo { Event = ev, SlotIndex = slot });
            }

            // compute SlotCount for each event (how many overlap with it)
            foreach (var r in result)
            {
                r.SlotCount = Math.Max(1, result.Count(x =>
                    x.Event.End > r.Event.Start &&
                    x.Event.Start < r.Event.End));
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Composite_Audio.Models
{
    public class AudioTimeline : IAudioTimeline
    {
        private readonly List<TimeSpan> _cuts;

        public string Title { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public IEnumerable<TimeSpan> Cuts => _cuts;

        public AudioTimeline(TimeSpan startTime, TimeSpan endTime)
        {
            StartTime = startTime;
            EndTime = endTime;

            _cuts = new List<TimeSpan>();
        }

        public void AddCut(TimeSpan cut)
        {
            _cuts.Add(cut);
        }

        public IEnumerable<string> ToOutputLines()
        {
            List<string> lines = new List<string>();

            lines.Add($"TITLE: {Title}");
            lines.Add($"START TIME: {StartTime}");
            lines.Add($"END TIME: {EndTime}");
            lines.Add("CUTS:");
            _cuts.ForEach(t => lines.Add(t.ToString()));

            return lines;
        }
    }
    
    public interface IAudioTimeline
    {
        TimeSpan StartTime { get; }
        TimeSpan EndTime { get; }
        IEnumerable<TimeSpan> Cuts { get; }

        IEnumerable<string> ToOutputLines();
    }
    public class CompositeAudioTimeline : IAudioTimeline
    {
        private readonly List<IAudioTimeline> _timelines = new List<IAudioTimeline>();

        public string Title { get; set; }
        public TimeSpan StartTime => _timelines.Min(t => t.StartTime);
        public TimeSpan EndTime => _timelines.Max(t => t.EndTime);
        public IEnumerable<TimeSpan> Cuts => _timelines.SelectMany(t => t.Cuts).OrderBy(c => c);

        public void Add(IAudioTimeline timeline)
        {
            _timelines.Add(timeline);
        }

        public IEnumerable<string> ToOutputLines()
        {
            List<string> lines = new List<string>();

            lines.Add($"TITLE: {Title}");
            lines.Add($"START TIME: {StartTime}");
            lines.Add($"END TIME: {EndTime}");
            lines.Add("CUTS:");
            lines.AddRange(Cuts.Select(c => c.ToString()));

            return lines;
        }
    }
}


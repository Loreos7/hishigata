using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Hishigata.Objects;

namespace osu.Game.Rulesets.Hishigata.Beatmaps
{
    public class HishigataBeatmap : Beatmap<HishigataHitObject>
    {
        public override IEnumerable<BeatmapStatistic> GetStatistics()
        {
            int notes = 0;
            int feigns = 0;
            int bonus = 0;

            foreach (var h in HitObjects)
            {
                switch (h)
                {
                    case HishigataBonus _:
                        ++bonus;
                        break;
                    case HishigataLanedHitObject n:
                        if (n.IsFeign) ++feigns;
                        else ++notes;
                        break;
                }
            }

            return new[]
            {
                new BeatmapStatistic
                {
                    Name = "Note Count",
                    Content = notes.ToString(),
                    CreateIcon = () => new BeatmapStatisticIcon(BeatmapStatisticsIconType.Circles),
                },
                new BeatmapStatistic
                {
                    Name = "Feign Count",
                    Content = feigns.ToString(),
                    CreateIcon = () => new BeatmapStatisticIcon(BeatmapStatisticsIconType.Circles),
                },
                new BeatmapStatistic
                {
                    Name = "Bonus Count",
                    Content = bonus.ToString(),
                    CreateIcon = () => new BeatmapStatisticIcon(BeatmapStatisticsIconType.Spinners),
                },
            };
        }
    }
}

﻿#region LICENSE
/*
    Sora - A Modular Bancho written in C#
    Copyright (C) 2019 Robin A. P.

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License as
    published by the Free Software Foundation, either version 3 of the
    License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Affero General Public License for more details.

    You should have received a copy of the GNU Affero General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
#endregion

// ReSharper disable UnusedAutoPropertyAccessor.Global

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Shared.Enums;
using Shared.Services;

namespace Shared.Models
{
    public class LeaderboardStd
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DefaultValue(0)]
        public ulong RankedScoreOsu { get; set; }

        [Required]
        [DefaultValue(0)]
        public ulong RankedScoreTaiko { get; set; }

        [Required]
        [DefaultValue(0)]
        public ulong RankedScoreCtb { get; set; }

        [Required]
        [DefaultValue(0)]
        public ulong RankedScoreMania { get; set; }

        [Required]
        [DefaultValue(0)]
        public ulong TotalScoreOsu { get; set; }

        [Required]
        [DefaultValue(0)]
        public ulong TotalScoreTaiko { get; set; }

        [Required]
        [DefaultValue(0)]
        public ulong TotalScoreCtb { get; set; }

        [Required]
        [DefaultValue(0)]
        public ulong TotalScoreMania { get; set; }

        [Required]
        [DefaultValue(0)]
        public ulong Count300Osu { get; set; }

        [Required]
        [DefaultValue(0)]
        public ulong Count300Taiko { get; set; }

        [Required]
        [DefaultValue(0)]
        public ulong Count300Ctb { get; set; }

        [Required]
        [DefaultValue(0)]
        public ulong Count300Mania { get; set; }


        [Required]
        [DefaultValue(0)]
        public ulong Count100Osu { get; set; }

        [Required]
        [DefaultValue(0)]
        public ulong Count100Taiko { get; set; }

        [Required]
        [DefaultValue(0)]
        public ulong Count100Ctb { get; set; }

        [Required]
        [DefaultValue(0)]
        public ulong Count100Mania { get; set; }


        [Required]
        [DefaultValue(0)]
        public ulong Count50Osu { get; set; }

        [Required]
        [DefaultValue(0)]
        public ulong Count50Taiko { get; set; }

        [Required]
        [DefaultValue(0)]
        public ulong Count50Ctb { get; set; }

        [Required]
        [DefaultValue(0)]
        public ulong Count50Mania { get; set; }


        [Required]
        [DefaultValue(0)]
        public ulong CountMissOsu { get; set; }

        [Required]
        [DefaultValue(0)]
        public ulong CountMissTaiko { get; set; }

        [Required]
        [DefaultValue(0)]
        public ulong CountMissCtb { get; set; }

        [Required]
        [DefaultValue(0)]
        public ulong CountMissMania { get; set; }

        [Required]
        [DefaultValue(0)]
        public ulong PlayCountOsu { get; set; }

        [Required]
        [DefaultValue(0)]
        public ulong PlayCountTaiko { get; set; }

        [Required]
        [DefaultValue(0)]
        public ulong PlayCountCtb { get; set; }

        [Required]
        [DefaultValue(0)]
        public ulong PlayCountMania { get; set; }

        [Required]
        [DefaultValue(0)]
        public double PerformancePointsOsu { get; set; }

        [Required]
        [DefaultValue(0)]
        public double PerformancePointsTaiko { get; set; }

        [Required]
        [DefaultValue(0)]
        public double PerformancePointsCtb { get; set; }

        [Required]
        [DefaultValue(0)]
        public double PerformancePointsMania { get; set; }


        public static LeaderboardStd GetLeaderboard(Database db, int userId)
        {
            LeaderboardStd result = db.LeaderboardStd.Where(t => t.Id == userId).Select(e => e).FirstOrDefault();
            if (result != null) return result;
            db.LeaderboardStd.Add(new LeaderboardStd {Id = userId});
            db.SaveChanges();
            return new LeaderboardStd {Id = userId};
        }

        public void IncreaseScore(Database db, ulong score, bool ranked, PlayMode mode)
        {
            switch (mode)
            {
                case PlayMode.Osu:
                    if (ranked)
                        RankedScoreOsu += score;
                    else
                        TotalScoreOsu += score;
                    break;
                case PlayMode.Taiko:
                    if (ranked)
                        RankedScoreTaiko += score;
                    else
                        TotalScoreTaiko += score;
                    break;
                case PlayMode.Ctb:
                    if (ranked)
                        RankedScoreCtb += score;
                    else
                        TotalScoreCtb += score;
                    break;
                case PlayMode.Mania:
                    if (ranked)
                        RankedScoreMania += score;
                    else
                        TotalScoreMania += score;
                    break;
            }

            db.LeaderboardStd.Update(this);
            db.SaveChanges();
        }
        public void IncreaseCount300(Database db, ulong c, PlayMode mode)
        {
            switch (mode)
            {
                case PlayMode.Osu:
                    Count300Osu += c;
                    break;
                case PlayMode.Taiko:
                    Count300Taiko += c;
                    break;
                case PlayMode.Ctb:
                    Count300Ctb += c;
                    break;
                case PlayMode.Mania:
                    Count300Mania += c;
                    break;
            }

            db.LeaderboardStd.Update(this);
            db.SaveChanges();
        }
        public void IncreaseCount100(Database db, ulong c, PlayMode mode)
        {
            switch (mode)
            {
                case PlayMode.Osu:
                    Count100Osu += c;
                    break;
                case PlayMode.Taiko:
                    Count100Taiko += c;
                    break;
                case PlayMode.Ctb:
                    Count100Ctb += c;
                    break;
                case PlayMode.Mania:
                    Count100Mania += c;
                    break;
            }

            db.LeaderboardStd.Update(this);
            db.SaveChanges();
        }
        public void IncreaseCount50(Database db, ulong c, PlayMode mode)
        {
            switch (mode)
            {
                case PlayMode.Osu:
                    Count50Osu += c;
                    break;
                case PlayMode.Taiko:
                    Count50Taiko += c;
                    break;
                case PlayMode.Ctb:
                    Count50Ctb += c;
                    break;
                case PlayMode.Mania:
                    Count50Mania += c;
                    break;
            }

            db.LeaderboardStd.Update(this);
            db.SaveChanges();
        }
        public void IncreaseCountMiss(Database db, ulong c, PlayMode mode)
        {
            switch (mode)
            {
                case PlayMode.Osu:
                    CountMissOsu += c;
                    break;
                case PlayMode.Taiko:
                    CountMissTaiko += c;
                    break;
                case PlayMode.Ctb:
                    CountMissCtb += c;
                    break;
                case PlayMode.Mania:
                    CountMissMania += c;
                    break;
            }

            db.LeaderboardStd.Update(this);
            db.SaveChanges();
        }
        public void IncreasePlaycount(Database db, PlayMode mode)
        {
            switch (mode)
            {
                case PlayMode.Osu:
                    PlayCountOsu++;
                    break;
                case PlayMode.Taiko:
                    PlayCountTaiko++;
                    break;
                case PlayMode.Ctb:
                    PlayCountCtb++;
                    break;
                case PlayMode.Mania:
                    PlayCountMania++;
                    break;
            }

            db.LeaderboardStd.Update(this);
            db.SaveChanges();
        }

        // I could do that better but this looks nice :3
        public uint GetPosition(Database db, PlayMode mode)
        {
            int pos = 0;
            switch (mode)
            {
                case PlayMode.Osu:
                    pos = db.LeaderboardStd.Count(x => x.PerformancePointsOsu > PerformancePointsOsu);
                    break;
                case PlayMode.Taiko:
                    pos = db.LeaderboardStd.Count(x => x.PerformancePointsTaiko > PerformancePointsTaiko);
                    break;
                case PlayMode.Ctb:
                    pos = db.LeaderboardStd.Count(x => x.PerformancePointsCtb > PerformancePointsCtb);
                    break;
                case PlayMode.Mania:
                    pos = db.LeaderboardStd.Count(x => x.PerformancePointsMania > PerformancePointsMania);
                    break;
            }
            return (uint) pos + 1;
        }

        public void UpdatePP(Database db, PlayMode mode)
        {
            double TotalPP = db.Scores.Where(s => (s.Mods & Mod.Relax) == 0).OrderByDescending(s => s.PeppyPoints)
                                    .Take(100).ToList().Select((t, i) => t.PeppyPoints * Math.Pow(0.95d, i)).Sum();

            switch (mode)
            {
                case PlayMode.Osu:
                    PerformancePointsOsu = TotalPP;
                    break;
                case PlayMode.Taiko:
                    PerformancePointsTaiko = TotalPP;
                    break;
                case PlayMode.Ctb:
                    PerformancePointsCtb = TotalPP;
                    break;
                case PlayMode.Mania:
                    PerformancePointsMania = TotalPP;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }

            db.LeaderboardStd.Update(this);
            db.SaveChanges();
        }
        
        public static LeaderboardStd GetLeaderboard(Database db, Users user) => GetLeaderboard(db, user.Id);
    }
}
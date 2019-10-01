#region LICENSE

/*
    olSora - A Modular Bancho written in C#
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

using System;
using Sora.Attributes;
using Sora.Enums;
using Sora.EventArgs.BanchoEventArgs;
using Sora.Framework.Enums;

namespace Sora.Events.BanchoEvents.Multiplayer.Match
{
    [EventClass]
    public class OnBanchoMatchChangeTeamEvent
    {
        [Event(EventType.BanchoMatchChangeTeam)]
        public void OnBanchoMatchChangeTeam(BanchoMatchChangeTeamArgs args)
        {
            var slot = args.pr.ActiveMatch?.GetSlotByUserId(args.pr.User.Id);
            if (slot == null)
                return;

            slot.Team = slot.Team switch
            {
                MultiSlotTeam.Blue => MultiSlotTeam.Red,
                MultiSlotTeam.Red => MultiSlotTeam.Blue,
                MultiSlotTeam.NoTeam => (new Random().Next(1) == 1 ? MultiSlotTeam.Red : MultiSlotTeam.Blue),
                _ => MultiSlotTeam.NoTeam
            };

            args.pr.ActiveMatch.Update();
        }
    }
}

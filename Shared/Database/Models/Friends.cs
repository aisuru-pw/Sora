#region copyright
/*
MIT License

Copyright (c) 2018 Robin A. P.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using JetBrains.Annotations;

namespace Shared.Database.Models
{
    [UsedImplicitly]
    public class Friends
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required] public int UserId { get; set; }

        [Required] [UsedImplicitly] public int FriendId { get; set; }

        public static IEnumerable<int> GetFriends(int userId)
        {
            using (SoraContext db = new SoraContext()) 
                return db.Friends.Where(t => t.UserId == userId).Select(x => x.FriendId).ToList();
        }

        public static void AddFriend(int userId, int friendId)
        {
            using (SoraContext db = new SoraContext())
            {
                db.Friends.Add(new Friends
                {
                    UserId   = userId,
                    FriendId = friendId
                });
                db.SaveChanges();
            }
        }
        
        public static void RemoveFriend(int userId, int friendId)
        {
            using (SoraContext db = new SoraContext())
            {
                db.RemoveRange(db.Friends.Where(x => x.UserId == userId && x.FriendId == friendId));
                db.SaveChanges();
            }
        }
    }
}
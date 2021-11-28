using System;
using System.Collections.Generic;

#pragma warning disable S2234

namespace TowersOfHanoi
{
    /// <summary>
    /// Static class TowerOfHanoi.
    /// </summary>
    public static class HanoiTowers
    {
        /// <summary>
        /// Get count of moves to move all disks from the first tower to the third.
        /// </summary>
        /// <param name="disks">Count of disks.</param>
        /// <returns>All moves.</returns>
        public static IEnumerable<(Tower, Tower)> GetMoves(int disks)
        {
            //2 ^ п - 1 steps.
            if (disks < 1 || disks > 30)
            {
                throw new ArgumentException("Count of disks should be more than 0 and less or equal 30.", nameof(disks));
            }

            return MoveDiscs(disks, Tower.From, Tower.To, Tower.Buffer);
        }

        private static IEnumerable<(Tower, Tower)> MoveDiscs(int countDiscs, Tower from, Tower to, Tower buffer)
        {
            if (countDiscs > 0)
            {
                foreach (var move in MoveDiscs(countDiscs - 1, from, buffer, to))
                {
                    yield return move;
                }
                    
                yield return (from, to);
                foreach (var move in MoveDiscs(countDiscs - 1, buffer, to, from))
                {
                    yield return move;
                }
            }
        }
    }
}

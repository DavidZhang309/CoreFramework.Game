using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace CoreFramework.Game.Grid
{
    public class GridChunkState : IGridState
    {
        protected Dictionary<Point, int[,]> Chunks { get; private set; }
        public int ChunkSize { get; private set; }

        public GridChunkState(int chunksize)
        {
            Chunks = new Dictionary<Point, int[,]>();
            ChunkSize = chunksize;
        }

        protected Point GetChunkPosition(Vector2 position)
        {
            return new Point(
                (int)position.X / ChunkSize,
                (int)position.Y / ChunkSize
            );
        }
        protected Point GetLocalGridPosition(Vector2 position)
        {
            int x = (int)Math.Floor(position.X % ChunkSize);
            int y = (int)Math.Floor(position.Y % ChunkSize);
            return new Point(
                x < 0 ? ChunkSize + x : x,
                y < 0 ? ChunkSize + y : y
            );
        }

        public int GetTile(Vector2 position)
        {
            Point chunkPosition = GetChunkPosition(position);
            Point localGridPosition = GetLocalGridPosition(position);

            int[,] chunk = null;
            Chunks.TryGetValue(chunkPosition, out chunk);

            return chunk == null ? -1 : chunk[localGridPosition.X, localGridPosition.Y];
        }
        public void SetTile(Vector2 position, int tileID)
        {
            Point chunkPosition = GetChunkPosition(position);
            Point localGridPosition = GetLocalGridPosition(position);

            int[,] chunk = null;
            if (!Chunks.TryGetValue(chunkPosition, out chunk)) {
                chunk = new int[ChunkSize, ChunkSize];
                Chunks[chunkPosition] = chunk;
            }

            chunk[localGridPosition.X, localGridPosition.Y] = tileID;
        }
    }
}

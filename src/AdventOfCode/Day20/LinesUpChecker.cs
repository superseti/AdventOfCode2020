namespace AdventOfCode.Day20
{
    public class LinesUpChecker
    {
        public LinesUpResult AreValid(Tile tileA, Tile tileB, ManipulaterTiles manipulater)
        {
            var result = this.CheckValid(tileA, tileB);
            if (result != null) { return result; }

            if (!tileB.IsArrangedToAny)
            {
                for (int ux = 0; ux < 3; ux++)
                {
                    manipulater.Rotate(tileB);

                    result = this.CheckValid(tileA, tileB);
                    if (result != null) { return result; }
                }

                manipulater.Flip(tileB);

                result = this.CheckValid(tileA, tileB);
                if (result != null) { return result; }

                for (int ux = 0; ux < 3; ux++)
                {
                    manipulater.Rotate(tileB);

                    result = this.CheckValid(tileA, tileB);
                    if (result != null) { return result; }
                }

                //manipulater.Rotate(tileB);

                //result = this.CheckValid(tileA, tileB);
                //if (result != null) { return result; }

                //manipulater.Rotate(tileB);

                //result = this.CheckValid(tileA, tileB);
                //if (result != null) { return result; }
            }

            return new LinesUpResult()
            {
                Success = false
            };
        }

        private LinesUpResult CheckValid(Tile tileA, Tile tileB)
        {
            var position = this.IsValidSituation(tileA, tileB);
            if (position.HasValue)
            {
                this.SetTilesReferenced(tileA, tileB, position.Value);
                return new LinesUpResult()
                {
                    Position = position.Value,
                    Success = true
                };
            }
            return null;
        }

        private void SetTilesReferenced(Tile tileA, Tile tileB, TilePosition position)
        {
            switch (position)
            {
                case TilePosition.Up:
                    tileA.TileUp = tileB;
                    tileB.TileDown = tileA;
                    break;
                case TilePosition.Down:
                    tileA.TileDown = tileB;
                    tileB.TileUp = tileA;
                    break;
                case TilePosition.Left:
                    tileA.TileLeft = tileB;
                    tileB.TileRight = tileA;
                    break;
                case TilePosition.Right:
                    tileA.TileRight = tileB;
                    tileB.TileLeft = tileA;
                    break;
            }
        }

        private TilePosition? IsValidSituation(Tile tileA, Tile tileB)
        {
            if (this.AreValidDown(tileA, tileB)) { return TilePosition.Down; }
            if (this.AreValidUp(tileA, tileB)) { return TilePosition.Up; }
            if (this.AreValidLeft(tileA, tileB)) { return TilePosition.Left; }
            if (this.AreValidRight(tileA, tileB)) { return TilePosition.Right; }
            return null;
        }

        private bool AreValidUp(Tile tileA, Tile tileB)
        {
            if (tileA.TileUp != null) { return false; }
            for (int ix = 0; ix < Tile.Size; ix++)
            {
                if (tileA.Data[0][ix] != tileB.Data[Tile.Size - 1][ix])
                {
                    return false;
                }
            }
            return true;
        }

        private bool AreValidDown(Tile tileA, Tile tileB)
        {
            if (tileA.TileDown != null) { return false; }
            for (int ix = 0; ix < Tile.Size; ix++)
            {
                if (tileA.Data[Tile.Size - 1][ix] != tileB.Data[0][ix])
                {
                    return false;
                }
            }
            return true;
        }

        private bool AreValidRight(Tile tileA, Tile tileB)
        {
            if (tileA.TileRight != null) { return false; }
            for (int ix = 0; ix < Tile.Size; ix++)
            {
                if (tileA.Data[ix][Tile.Size - 1] != tileB.Data[ix][0])
                {
                    return false;
                }
            }
            return true;
        }

        private bool AreValidLeft(Tile tileA, Tile tileB)
        {
            if (tileA.TileLeft != null) { return false; }
            for (int ix = 0; ix < Tile.Size; ix++)
            {
                if (tileA.Data[ix][0] != tileB.Data[ix][Tile.Size - 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}

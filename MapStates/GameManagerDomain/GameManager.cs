using MapStates.ActionDomain;
using MapStates.AdventurerDomain;
using MapStates.FileInterpreterDomain;
using MapStates.OrientationDomain;
using MapStates.TreasureMapDomain;
using System;
using System.Collections.Generic;

namespace MapStates.GameManagerDomain
{
    public class GameManager
    {
        private ITreasureMap GameMap { get; set; }
        public GameManager()
        {
            GameMap = new TreasureMap();
        }

        public IList<string> RunGame(IList<string> fileLines)
        {
            IFileInterpreter fileInterpreter = new FileInterpreter();
            GameMap = fileInterpreter.CreateMapFromFile(fileLines);
            #region gamePlay
            var mapHistory = new MapStateHistory();
            mapHistory.Push(GameMap.CreateState());
            while (ContinueGame())
            {
                foreach (var item in GameMap.GetAdventurers())
                {
                    item.ExecuteAction();
                    mapHistory.Push(GameMap.CreateState());
                }
            }
            var gameResult = fileInterpreter.CreateFileContentFromMap(GameMap);
            return gameResult;

            //return mapHistory;
            #endregion
        }

        public MapStateHistory RunStepByStep(IList<string> fileLines)
        {        
                IFileInterpreter fileInterpreter = new FileInterpreter();
                GameMap = fileInterpreter.CreateMapFromFile(fileLines);
                #region gamePlay
                var mapHistory = new MapStateHistory();
                mapHistory.Push(GameMap.CreateState());
                while (ContinueGame())
                {
                    foreach (var item in GameMap.GetAdventurers())
                    {
                        item.ExecuteAction();
                        mapHistory.Push(GameMap.CreateState());
                    }
                }
                //var gameResult = fileInterpreter.CreateFileContentFromMap(GameMap);
                //return gameResult;

                return mapHistory;
                #endregion
            }

            private bool ContinueGame()
        {
            foreach (var item in GameMap.GetAdventurers())
            {
                if (item.Actions.Count > 0)
                    return true;
            }
            return false;
        }
    }
}

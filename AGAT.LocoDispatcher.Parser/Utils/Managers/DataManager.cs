using AGAT.locoDispatcher.ArchiveDB.Repositories;
using AGAT.LocoDispatcher.Data.Repositories;
using AGAT.LocoDispatcher.RailData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGAT.LocoDispatcher.Parser.Utils.Managers
{
    public class DataManager
    {
        public DataManager()
        {
            startEventRepository = new StartEventRepository();
            stopEventRepository = new StopEventRepository();
            checkpointEventRepository = new CheckpointEventRepository();
            emergencyRepository = new EmergencyRepository();
            shiftRepository = new ShiftRepository();
            trackRepository = new TrackRepository();
            pointRepository = new PointRepository();
        }
        public StartEventRepository startEventRepository { get; set; }
        public StopEventRepository stopEventRepository { get; set; }
        public CheckpointEventRepository checkpointEventRepository { get; set; }
        public EmergencyRepository emergencyRepository { get; set; }
        public ShiftRepository shiftRepository { get; set; }
        public TrackRepository trackRepository { get; set; }
        public PointRepository pointRepository { get; set; }
    }
}
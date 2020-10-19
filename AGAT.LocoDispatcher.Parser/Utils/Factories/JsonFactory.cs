using AGAT.LocoDispatcher.Common.Interfaces;
using AGAT.LocoDispatcher.Constants;
using AGAT.LocoDispatcher.Parser.Models;
using AGAT.LocoDispatcher.Parser.Utils.Events;
using AGAT.LocoDispatcher.Parser.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AGAT.LocoDispatcher.Parser.Utils.Factories
{
    public class JsonFactory
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private EventManager _eventManager = new EventManager();
        public EventManager GetEvents()
        {
            return this._eventManager;
        }
        public IEvent GetEventFactory(dynamic jsonObject)
        {
            switch (jsonObject.type.ToString())
            {
                case EventConstants.StartMoveEvent:
                    try
                    {
                        logger.Info("START MOVE INVOKED");
                        StartMoveEvent startEvent = new StartMoveEvent(
                            jsonObject.type.ToString(),
                            (int)jsonObject.timestamp,
                            ConvertHelper.DynamicToDouble(jsonObject.direction),
                            (int)jsonObject.direction_parity,
                            jsonObject.message.ToString(),
                            jsonObject.train_id.ToString(),
                            jsonObject.track_number.ToString(),
                            jsonObject.checkpoint_number.ToString());
                        return startEvent;
                    }

                    catch (FormatException ex)
                    {
                        throw ex;
                    }
                case EventConstants.StopMoveEvent:
                    try
                    {
                        logger.Info("STOP MOVE INVOKED");
                        StopMoveEvent stopEvent = new StopMoveEvent(
                            jsonObject.type.ToString(),
                            (int)jsonObject.timestamp,
                            ConvertHelper.DynamicToDouble(jsonObject.distance),
                            jsonObject.checkpoint_number.ToString(),
                            jsonObject.track_number.ToString(),
                            jsonObject.message.ToString(),
                            jsonObject.train_id.ToString()
                            );
                        return stopEvent;
                    }
                    catch (FormatException ex)
                    {
                        throw ex;
                    }
                case EventConstants.PassCheckpoint:
                    try
                    {
                        logger.Info("PASS CHECKPOINT INVOKED");
                        CheckpointEvent checkpointEvent = new CheckpointEvent(
                            jsonObject.type.ToString(),
                            (int)jsonObject.timestamp,
                            jsonObject.train_id.ToString(),
                            ConvertHelper.DynamicToDouble(jsonObject.speed),
                            jsonObject.checkpoint_number.ToString(),
                            jsonObject.track_number.ToString(),
                            jsonObject.message.ToString()
                            );
                        return checkpointEvent;
                    }
                    catch (FormatException ex)
                    {
                        throw ex;
                    }
                case EventConstants.StopOutsideStation:
                    try
                    {
                        logger.Info("STOP OUTSIDE INVOKED");
                        StopMoveEvent stopEvent = new StopMoveEvent(
                                jsonObject.type.ToString(),
                                (int)jsonObject.timestamp,
                                ConvertHelper.DynamicToDouble(jsonObject.distance),
                                jsonObject.checkpoint_number.ToString(),
                                jsonObject.track_number.ToString(),
                                jsonObject.message.ToString(),
                                jsonObject.train_id.ToString()
                                );
                        return stopEvent;
                    }
                    catch (FormatException ex)
                    {
                        throw ex;
                    }
                case EventConstants.Emergency:
                    try
                    {
                        logger.Info("EMERGENCY INVOKED");
                        EmergencyEvent emergencyEvent = new EmergencyEvent(
                              jsonObject.type.ToString(),
                                (int)jsonObject.timestamp,
                                jsonObject.train_id.ToString(),
                                jsonObject.emergency_type.ToString(),
                                (int)jsonObject.emergency_status,
                                jsonObject.message.ToString());
                        return emergencyEvent;
                    }
                    catch (FormatException ex)
                    {
                        throw ex;
                    }
                case EventConstants.StartShiftLocomotives:
                    try
                    {
                        logger.Info("LOCOMOTIVE SHIFTS INVOKED");
                        List<string> _trains = new List<string>();
                        dynamic trains = jsonObject.trains;
                        foreach (var train in trains)
                        {
                            _trains.Add(train.train_id.ToString());
                        }

                        ShiftLocomotiveEvent shiftLocomotive = new ShiftLocomotiveEvent(
                             jsonObject.type.ToString(),
                                (int)jsonObject?.timestamp,
                                jsonObject?.esr.ToString(),
                                _trains
                            );
                        return shiftLocomotive;
                    }
                    catch (FormatException ex)
                    {
                        throw ex;
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                default:
                    logger.Info($"!!! DEFAULT INVOKED, TYPE IS {jsonObject.type.ToString()}");
                    return null;
            }
        }

        public void SetEventManagerFactory(IEvent jsonEvent)
        {
            try
            {
                switch (jsonEvent.Type)
                {
                    case EventConstants.StartMoveEvent:
                        _eventManager.StartEvent.Add((StartMoveEvent)jsonEvent);
                        break;
                    case EventConstants.PassCheckpoint:
                        _eventManager.CheckpointEvent.Add((CheckpointEvent)jsonEvent);
                        break;
                    case EventConstants.StopMoveEvent:
                        _eventManager.StopEvent.Add((StopMoveEvent)jsonEvent);
                        break;
                    case EventConstants.Emergency:
                        _eventManager.EmergencyEvent.Add((EmergencyEvent)jsonEvent);
                        break;
                    case EventConstants.StopOutsideStation:
                        _eventManager.StopEvent.Add((StopMoveEvent)jsonEvent);
                        break;
                    case EventConstants.StartShiftLocomotives:
                        _eventManager.LocoShiftEvent.Add((ShiftLocomotiveEvent)jsonEvent);
                        break;
                    default:
                        Console.WriteLine($"Couldnt find event {jsonEvent.Type}");
                        break;

                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

    }
}
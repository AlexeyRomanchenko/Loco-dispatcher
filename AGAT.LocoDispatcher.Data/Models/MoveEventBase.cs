using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGAT.LocoDispatcher.Data.Events
{
    [Table("Events")]
    public class MoveEventBase
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public int Timestamp { get; set; }
        public string Message { get; set; }
        public int ShiftId { get; set; }
        public LocoShiftEvent Shift { get; set; }
        public string CheckPointNumber { get; set; }
        public string TrackNumber { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

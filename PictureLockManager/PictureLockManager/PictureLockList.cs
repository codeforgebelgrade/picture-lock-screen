using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Codeforge.PictureLockCommons
{
    /// <summary>
    /// This class represents the structure of the JSON file that will contain information about the pictures
    /// </summary>
    [DataContract]
    public class PictureLockList
    {
        [DataMember(Name = "pictures")]
        public List<PictureLockListItem> PictureLockItems { get; set; }

        public class PictureLockListItem
        {
            [DataMember(Name = "file")]
            public String FilePath { get; set; }
            [DataMember(Name = "password")]
            public String Password { get; set; }
        }

    }
}

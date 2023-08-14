﻿using System;

namespace AccountingManagement.Common
{
    public abstract class BaseEntity
    {
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}

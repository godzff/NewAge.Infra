﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NewAge.Infra.Options
{
    /// <summary>
    /// 雪花算法的参数配置
    /// </summary>
    public class SnowFlakeOption
    {
        /// <summary>
        /// 工作Id 只能1-1022
        /// </summary>
        public int WorkId { get; set; }
    }
}

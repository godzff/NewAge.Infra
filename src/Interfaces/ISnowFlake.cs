using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewAge.Infra.Interfaces
{
    public interface ISnowFlake
    {
        /// <summary>
        /// 获取id
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        Task<long> NextIdAsync();

        /// <summary>
        /// 获取id
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        long NextId();
    }
}

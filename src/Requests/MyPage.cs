using System;
using System.Collections.Generic;
using System.Text;

namespace NewAge.Infra.Requests
{
    public class MyPage
    {
        private int _PageIndex;
        /// <summary>
        /// 页索引，即第几页，从1开始
        /// </summary>
        public int PageIndex
        {
            get
            {
                if (_PageIndex <= 0)
                    _PageIndex = 1;
                return _PageIndex;
            }
            set { _PageIndex = value; }
        }
        /// <summary>
        /// 每页显示行数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 总行数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount
        {
            get
            {
                if (TotalCount == 0)
                    return 0;
                if ((TotalCount % PageSize) == 0)
                    return TotalCount / PageSize;
                return (TotalCount / PageSize) + 1;
            }
        }
        /// <summary>
        /// 初始化分页
        /// </summary>
        public MyPage()
            : this(1)
        {
        }
        /// <summary>
        /// 初始化分页
        /// </summary>
        /// <param name="page">页索引</param>
        /// <param name="pageSize">每页显示行数,默认20</param> 
        /// <param name="totalCount">总行数</param>
        public MyPage(int page, int pageSize = 30, int totalCount = 0)
        {
            PageIndex = page;
            PageSize = pageSize;
            TotalCount = totalCount;
        }
    }

}

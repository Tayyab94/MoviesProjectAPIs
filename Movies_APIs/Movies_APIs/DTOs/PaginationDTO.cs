using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_APIs.DTOs
{
    public class PaginationDTO
    {
        public int Page { get; set; } = 1;

        public int recordsPerPage = 5;

        private readonly int maxAmount = 50;

        public int RecorsPerPage
        {
            get
            {
                return recordsPerPage;
            }

            set
            {
                recordsPerPage = (value > maxAmount) ? maxAmount : value;
            }
        }
    }
}

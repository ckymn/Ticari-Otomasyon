using System.Data;

namespace gridView1
{
    internal class GetDataRow : DataRow
    {
        private int focusedRowHandle;

        public GetDataRow(int focusedRowHandle)
        {
            this.focusedRowHandle = focusedRowHandle;
        }
    }
}
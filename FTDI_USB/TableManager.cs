using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq.Expressions;
using System.Windows.Forms;
using DebugToolsLib;

namespace FTDI_USB
{
    public class TableManager
    {
        public class Сonstant
        {
            /// <summary>
            ///  Константа 
            /// </summary>
            public static int BoundTable_OZU = 0x0
            /// <summary>
            /// Константа 0x0
            /// </summary>
            public static int OffsetByCols = 0x0;
        }

        public static UInt16 _defaultValue;

        public static UInt16 DefaultValue
        {
            get { return _defaultValue; }
            set { _defaultValue = value; }
        }

        public void DataGrid_HexCellFormattingDefault(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if ((ushort)e.Value != DefaultValue)
                    e.CellStyle.BackColor = Color.PowderBlue;
                e.Value = string.Format("{0:X4}", e.Value);

                e.FormattingApplied = true;
            }
        }

        public void DataGrid_HexCellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            try
            {
                e.Value = ushort.Parse(e.Value.ToString(), System.Globalization.NumberStyles.HexNumber);
            }
            catch
            {
                e.Value = (ushort)0;
            }
            e.ParsingApplied = true;
        }

        /// <summary>
        /// Заполняет строки 
        /// </summary>
        public static void DataGridFill(DataGridView FlashDataGrid, ProgressBar tspb)
        {
            var max = tspb.Maximum;
            int end = Сonstant.BoundTable_OZU;

            tspb.Maximum = end;
            for (int i = 0, j = 0; i < end; i += Сonstant.OffsetByCols, j++)
            {
                FlashDataGrid.Rows.Add();
                FlashDataGrid.Rows[j].HeaderCell.Value = string.Format("{0:X3}", i);
                tspb.Increment(1);
            }
            tspb.Value = 0;
            tspb.Maximum = max;
        }

        /// <summary>
        /// Заполняет инциализирующим данным таблицу ОЗУ
        /// </summary>
        /// <param name="grid">Таблица вывода</param>
        /// <param name="initValue"></param>
        public static void InitCells(DataGridView grid, UInt16 initValue)
        {
            int ptr_col = 0;
            int ptr_row = -1;
            DefaultValue = initValue;

            for (UInt16 Address = 0x0; Address < Сonstant.BoundTable_OZU; Address++, ptr_col++)
            {
                if (Address % Сonstant.OffsetByCols == 0) { ptr_col = 0; ptr_row++; }

                grid[ptr_col, ptr_row].Value = initValue;
            }
        }

        /// <summary>
        /// Заполняет инциализирующим данным таблицу ОЗУ
        /// </summary>
        /// <param name="grid">Таблица вывода</param>
        /// <param name="initValue"></param>
        public static void InitRangeCells(DataGridView grid, uint indexFrom, uint indexTo, uint loadCount = 0)
        {
            int ptr_col = 0;
            int ptr_row = -1;
            Color color;
            if (indexTo < Сonstant.BoundTable_OZU && indexFrom <= indexTo)
                for (UInt16 Address = 0x0; Address < Сonstant.BoundTable_OZU; Address++, ptr_col++)
                {
                    if (Address % Сonstant.OffsetByCols == 0) { ptr_col = 0; ptr_row++; }

                    if (grid[ptr_col, ptr_row].Style.BackColor != Color.PowderBlue)
                    {
                        if (indexFrom <= Address && Address <= indexTo)
                            color = Color.White;
                        else
                            color = Color.Gray;
                        grid[ptr_col, ptr_row].Style.BackColor = color;
                    }
                }
        }
        /// <summary>
        /// Заполняет инциализирующим данным таблицу ОЗУ
        /// </summary>
        /// <param name="grid">Таблица вывода</param>
        /// <param name="initValue"></param>
        public static void InitLoadsCells(DataGridView grid, uint indexFrom, uint loadCount)
        {
            int ptr_col = (int) (indexFrom % Сonstant.OffsetByCols);
            int ptr_row = (int) (indexFrom / Сonstant.OffsetByCols);
            try
            {
                if (loadCount + indexFrom < Сonstant.BoundTable_OZU)
                    for (uint Address = indexFrom; Address < indexFrom + loadCount; Address++, ptr_col++)
                    {
                        if (Address%Сonstant.OffsetByCols == 0)
                        {
                            if (ptr_col != 0)
                                ptr_row++;
                            ptr_col = 0;
                        }

                        if (grid[ptr_col, ptr_row].Style.BackColor != Color.PowderBlue)
                            grid[ptr_col, ptr_row].Style.BackColor = Color.LawnGreen;
                    }
            }
            catch (Exception e)
            {
                MessageCLI.PrintInDialog(e.Message, "Error is appear in during initialization table");
            }
        }

        /// <summary>
        /// Извлекает из таблицы массив значений ячеек
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static UInt16[] GetSeriesCellValues(DataGridView grid)
        {
            List<UInt16> listCells = new List<UInt16>(grid.RowCount * grid.ColumnCount);
            foreach (DataGridViewRow row in grid.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    listCells.Add((ushort) cell.Value);
                }
            }
            return listCells.ToArray();
        }
    }
}
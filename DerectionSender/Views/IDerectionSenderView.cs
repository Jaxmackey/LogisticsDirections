using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DerectionSender.Views
{
    public interface IDerectionSenderView: IView
    {
        string FromDerection { get;}
        string[] SetFromDerectionCombobox { set; }
        string ToDerection { get;}
        string[] SetToDerectionCombobox { set; }
        string FromIndex { get; set; }
        string ToIndex { get; set; }
        string EmailTextBox { get; set; }
        string PasswordTextBox { get; set; }
        string SubjectTextBox { get; set; }
        string RichEmailTextBox { get; set; }
        DataGridView dataGrid { get; }
        void ClearGrid();
        void AddRowToGrid(params object[] cells);
        void GridInvoke(Delegate method);
        int GetGridIndexByCellValue(string cellHeaderText, string cellInnerText);
        void ChangeValueAndColorCellByIndex(int rowIndex, int cellIndex, string status, Color color);
        Button StartSendButton { get; }
        event Action Create;
        event Action InitComboboxies;
        event Action Start;
        event Action DeleteAll;
        void ShowValidateError(string message);
    }
}

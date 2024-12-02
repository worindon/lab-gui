using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

public class ConsoleToRichTextBox : TextWriter
{
    private RichTextBox richTextBox;

    // Конструктор принимает RichTextBox, в который будет перенаправлен вывод
    public ConsoleToRichTextBox(RichTextBox rtb)
    {
        this.richTextBox = rtb;
    }

    // Переопределяем Encoding, чтобы TextWriter знал, в какой кодировке работать
    public override Encoding Encoding => Encoding.UTF8;

    // Переопределяем Write для одиночных символов
    public override void Write(char value)
    {
        // Используем Invoke для потокобезопасности
        if (richTextBox.InvokeRequired)
        {
            richTextBox.Invoke(new Action(() => richTextBox.AppendText(value.ToString())));
        }
        else
        {
            richTextBox.AppendText(value.ToString());
        }
    }

    // Переопределяем Write для строк
    public override void Write(string value)
    {
        // Используем Invoke для потокобезопасности
        if (richTextBox.InvokeRequired)
        {
            richTextBox.Invoke(new Action(() => richTextBox.AppendText(value)));
        }
        else
        {
            richTextBox.AppendText(value);
        }
    }
}

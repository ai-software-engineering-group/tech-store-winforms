using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTPM_AI_CT3.Utils
{
    public class PaginateUtils
    {
        public static void RenderPaginateButtons(int currentPage, int totalPages, Panel panel, EventHandler onPageClick)
        {
            panel.Controls.Clear();

            int buttonWidth = 27;
            int buttonHeight = 27;
            int margin = 3;

            int xPosition = margin;

            if (currentPage > 1 && totalPages > 2)
            {
                Button firstPageButton = new Button
                {
                    Text = "<<",
                    Width = buttonWidth,
                    Height = buttonHeight,
                    Location = new Point(xPosition, margin),
                };
                firstPageButton.Click += (s, e) => onPageClick?.Invoke(1, EventArgs.Empty);
                panel.Controls.Add(firstPageButton);
                xPosition += buttonWidth + margin;
            }

            if (currentPage > 1)
            {
                Button prevButton = new Button
                {
                    Text = "<",
                    Width = buttonWidth,
                    Height = buttonHeight,
                    Location = new Point(xPosition, margin),
                };
                prevButton.Click += (s, e) => onPageClick?.Invoke(currentPage - 1, EventArgs.Empty);
                panel.Controls.Add(prevButton);
                xPosition += buttonWidth + margin;
            }

            int startPage = currentPage > 1 ? currentPage - 1 : 1;
            int endPage = currentPage < totalPages ? currentPage + 1 : totalPages;

            if (totalPages > 3)
            {
                if (currentPage == 1)
                {
                    endPage = Math.Min(3, totalPages);
                }
                else if (currentPage == totalPages)
                {
                    startPage = Math.Max(totalPages - 2, 1);
                }
            }

            if (startPage > 1)
            {
                Label ellipsisStart = new Label
                {
                    Text = "...",
                    Width = buttonWidth,
                    Height = buttonHeight,
                    Location = new Point(xPosition, margin),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                panel.Controls.Add(ellipsisStart);
                xPosition += buttonWidth + margin;
            }

            for (int i = startPage; i <= endPage; i++)
            {
                int page = i;

                Button pageButton = new Button
                {
                    Text = i.ToString(),
                    Width = buttonWidth,
                    Height = buttonHeight,
                    Location = new Point(xPosition, margin),
                    BackColor = i == currentPage ? Color.LightBlue : Color.White
                };
                pageButton.Click += (s, e) => onPageClick?.Invoke(page, EventArgs.Empty);
                panel.Controls.Add(pageButton);
                xPosition += buttonWidth + margin;
            }

            if (endPage < totalPages)
            {
                Label ellipsisEnd = new Label
                {
                    Text = "...",
                    Width = buttonWidth,
                    Height = buttonHeight,
                    Location = new Point(xPosition, margin),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                panel.Controls.Add(ellipsisEnd);
                xPosition += buttonWidth + margin;
            }

            if (currentPage < totalPages)
            {
                Button nextButton = new Button
                {
                    Text = ">",
                    Width = buttonWidth,
                    Height = buttonHeight,
                    Location = new Point(xPosition, margin),
                };
                nextButton.Click += (s, e) => onPageClick?.Invoke(currentPage + 1, EventArgs.Empty);
                panel.Controls.Add(nextButton);
                xPosition += buttonWidth + margin;
            }

            if (currentPage < totalPages && totalPages > 2)
            {
                Button lastPageButton = new Button
                {
                    Text = ">>",
                    Width = buttonWidth,
                    Height = buttonHeight,
                    Location = new Point(xPosition, margin),
                };
                lastPageButton.Click += (s, e) => onPageClick?.Invoke(totalPages, EventArgs.Empty);
                panel.Controls.Add(lastPageButton);
            }
        }
    }
}

namespace Path_Finding_Algorithms_Visualization
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxW = new System.Windows.Forms.TextBox();
            this.textBoxH = new System.Windows.Forms.TextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.textBoxLogs = new System.Windows.Forms.TextBox();
            this.buttonRestartMap = new System.Windows.Forms.Button();
            this.buttonStartDijkstra = new System.Windows.Forms.Button();
            this.buttonStartA = new System.Windows.Forms.Button();
            this.buttonClearPath = new System.Windows.Forms.Button();
            this.buttonDepthFirstSearch = new System.Windows.Forms.Button();
            this.buttonRandomMap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(24, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(20, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Height";
            // 
            // textBoxW
            // 
            this.textBoxW.Location = new System.Drawing.Point(69, 12);
            this.textBoxW.Name = "textBoxW";
            this.textBoxW.Size = new System.Drawing.Size(100, 23);
            this.textBoxW.TabIndex = 3;
            this.textBoxW.Text = "18";
            // 
            // textBoxH
            // 
            this.textBoxH.Location = new System.Drawing.Point(69, 41);
            this.textBoxH.Name = "textBoxH";
            this.textBoxH.Size = new System.Drawing.Size(100, 23);
            this.textBoxH.TabIndex = 4;
            this.textBoxH.Text = "10";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(175, 11);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 5;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(175, 40);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 6;
            this.buttonClear.Text = "Clear Map";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // textBoxLogs
            // 
            this.textBoxLogs.Location = new System.Drawing.Point(580, 11);
            this.textBoxLogs.Multiline = true;
            this.textBoxLogs.Name = "textBoxLogs";
            this.textBoxLogs.ReadOnly = true;
            this.textBoxLogs.Size = new System.Drawing.Size(162, 81);
            this.textBoxLogs.TabIndex = 7;
            // 
            // buttonRestartMap
            // 
            this.buttonRestartMap.Location = new System.Drawing.Point(256, 40);
            this.buttonRestartMap.Name = "buttonRestartMap";
            this.buttonRestartMap.Size = new System.Drawing.Size(156, 23);
            this.buttonRestartMap.TabIndex = 9;
            this.buttonRestartMap.Text = "Restart Map";
            this.buttonRestartMap.UseVisualStyleBackColor = true;
            this.buttonRestartMap.Click += new System.EventHandler(this.buttonRestartMap_Click);
            // 
            // buttonStartDijkstra
            // 
            this.buttonStartDijkstra.Location = new System.Drawing.Point(418, 12);
            this.buttonStartDijkstra.Name = "buttonStartDijkstra";
            this.buttonStartDijkstra.Size = new System.Drawing.Size(156, 23);
            this.buttonStartDijkstra.TabIndex = 10;
            this.buttonStartDijkstra.Text = "Start Dijkstra";
            this.buttonStartDijkstra.UseVisualStyleBackColor = true;
            this.buttonStartDijkstra.Click += new System.EventHandler(this.buttonStartDijkstra_Click);
            // 
            // buttonStartA
            // 
            this.buttonStartA.Location = new System.Drawing.Point(418, 40);
            this.buttonStartA.Name = "buttonStartA";
            this.buttonStartA.Size = new System.Drawing.Size(156, 23);
            this.buttonStartA.TabIndex = 11;
            this.buttonStartA.Text = "Start A*";
            this.buttonStartA.UseVisualStyleBackColor = true;
            this.buttonStartA.Click += new System.EventHandler(this.buttonStartA_Click);
            // 
            // buttonClearPath
            // 
            this.buttonClearPath.Location = new System.Drawing.Point(175, 69);
            this.buttonClearPath.Name = "buttonClearPath";
            this.buttonClearPath.Size = new System.Drawing.Size(75, 23);
            this.buttonClearPath.TabIndex = 12;
            this.buttonClearPath.Text = "Clear Path";
            this.buttonClearPath.UseVisualStyleBackColor = true;
            this.buttonClearPath.Click += new System.EventHandler(this.buttonClearPath_Click);
            // 
            // buttonDepthFirstSearch
            // 
            this.buttonDepthFirstSearch.Location = new System.Drawing.Point(418, 69);
            this.buttonDepthFirstSearch.Name = "buttonDepthFirstSearch";
            this.buttonDepthFirstSearch.Size = new System.Drawing.Size(156, 23);
            this.buttonDepthFirstSearch.TabIndex = 14;
            this.buttonDepthFirstSearch.Text = "Depth First Search";
            this.buttonDepthFirstSearch.UseVisualStyleBackColor = true;
            this.buttonDepthFirstSearch.Click += new System.EventHandler(this.buttonDepthFirstSearch_Click);
            // 
            // buttonRandomMap
            // 
            this.buttonRandomMap.Location = new System.Drawing.Point(256, 12);
            this.buttonRandomMap.Name = "buttonRandomMap";
            this.buttonRandomMap.Size = new System.Drawing.Size(156, 23);
            this.buttonRandomMap.TabIndex = 15;
            this.buttonRandomMap.Text = "Random Map";
            this.buttonRandomMap.UseVisualStyleBackColor = true;
            this.buttonRandomMap.Click += new System.EventHandler(this.buttonRandomMap_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(753, 517);
            this.Controls.Add(this.buttonRandomMap);
            this.Controls.Add(this.buttonDepthFirstSearch);
            this.Controls.Add(this.buttonClearPath);
            this.Controls.Add(this.buttonStartA);
            this.Controls.Add(this.buttonStartDijkstra);
            this.Controls.Add(this.buttonRestartMap);
            this.Controls.Add(this.textBoxLogs);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.textBoxH);
            this.Controls.Add(this.textBoxW);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxW;
        private System.Windows.Forms.TextBox textBoxH;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.TextBox textBoxLogs;
        private System.Windows.Forms.Button buttonRestartMap;
        private System.Windows.Forms.Button buttonStartDijkstra;
        private System.Windows.Forms.Button buttonStartA;
        private System.Windows.Forms.Button buttonClearPath;
        private System.Windows.Forms.Button buttonDepthFirstSearch;
        private System.Windows.Forms.Button buttonRandomMap;
    }
}

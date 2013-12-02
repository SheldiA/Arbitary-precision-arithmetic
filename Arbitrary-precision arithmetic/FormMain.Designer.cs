namespace Arbitrary_precision_arithmetic
{
    partial class FormMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.gb_operations = new System.Windows.Forms.GroupBox();
            this.rb_karatsubaMultiplication = new System.Windows.Forms.RadioButton();
            this.rb_dividing = new System.Windows.Forms.RadioButton();
            this.rb_multiplication = new System.Windows.Forms.RadioButton();
            this.rb_addition = new System.Windows.Forms.RadioButton();
            this.tb_leftOperand = new System.Windows.Forms.TextBox();
            this.tb_rightOperand = new System.Windows.Forms.TextBox();
            this.tb_result = new System.Windows.Forms.TextBox();
            this.lb_line = new System.Windows.Forms.Label();
            this.bt_calculate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_numeralSystem = new System.Windows.Forms.TextBox();
            this.tb_leftSign = new System.Windows.Forms.TextBox();
            this.tb_rightSign = new System.Windows.Forms.TextBox();
            this.tb_resultSign = new System.Windows.Forms.TextBox();
            this.lb_sign = new System.Windows.Forms.Label();
            this.lb_runningTime = new System.Windows.Forms.Label();
            this.gb_operations.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_operations
            // 
            this.gb_operations.Controls.Add(this.rb_karatsubaMultiplication);
            this.gb_operations.Controls.Add(this.rb_dividing);
            this.gb_operations.Controls.Add(this.rb_multiplication);
            this.gb_operations.Controls.Add(this.rb_addition);
            this.gb_operations.Location = new System.Drawing.Point(11, 15);
            this.gb_operations.Name = "gb_operations";
            this.gb_operations.Size = new System.Drawing.Size(174, 121);
            this.gb_operations.TabIndex = 0;
            this.gb_operations.TabStop = false;
            this.gb_operations.Text = "Choose operation:";
            // 
            // rb_karatsubaMultiplication
            // 
            this.rb_karatsubaMultiplication.AutoSize = true;
            this.rb_karatsubaMultiplication.Location = new System.Drawing.Point(15, 75);
            this.rb_karatsubaMultiplication.Name = "rb_karatsubaMultiplication";
            this.rb_karatsubaMultiplication.Size = new System.Drawing.Size(136, 17);
            this.rb_karatsubaMultiplication.TabIndex = 3;
            this.rb_karatsubaMultiplication.TabStop = true;
            this.rb_karatsubaMultiplication.Text = "Karatsuba multiplication";
            this.rb_karatsubaMultiplication.UseVisualStyleBackColor = true;
            this.rb_karatsubaMultiplication.CheckedChanged += new System.EventHandler(this.RadioButton_Checked);
            // 
            // rb_dividing
            // 
            this.rb_dividing.AutoSize = true;
            this.rb_dividing.Location = new System.Drawing.Point(15, 98);
            this.rb_dividing.Name = "rb_dividing";
            this.rb_dividing.Size = new System.Drawing.Size(63, 17);
            this.rb_dividing.TabIndex = 2;
            this.rb_dividing.TabStop = true;
            this.rb_dividing.Text = "Dividing";
            this.rb_dividing.UseVisualStyleBackColor = true;
            this.rb_dividing.CheckedChanged += new System.EventHandler(this.RadioButton_Checked);
            // 
            // rb_multiplication
            // 
            this.rb_multiplication.AutoSize = true;
            this.rb_multiplication.Location = new System.Drawing.Point(15, 47);
            this.rb_multiplication.Name = "rb_multiplication";
            this.rb_multiplication.Size = new System.Drawing.Size(86, 17);
            this.rb_multiplication.TabIndex = 1;
            this.rb_multiplication.TabStop = true;
            this.rb_multiplication.Text = "Multiplication";
            this.rb_multiplication.UseVisualStyleBackColor = true;
            this.rb_multiplication.CheckedChanged += new System.EventHandler(this.RadioButton_Checked);
            // 
            // rb_addition
            // 
            this.rb_addition.AutoSize = true;
            this.rb_addition.Checked = true;
            this.rb_addition.Location = new System.Drawing.Point(14, 22);
            this.rb_addition.Name = "rb_addition";
            this.rb_addition.Size = new System.Drawing.Size(63, 17);
            this.rb_addition.TabIndex = 0;
            this.rb_addition.TabStop = true;
            this.rb_addition.Text = "Addition";
            this.rb_addition.UseVisualStyleBackColor = true;
            this.rb_addition.CheckedChanged += new System.EventHandler(this.RadioButton_Checked);
            // 
            // tb_leftOperand
            // 
            this.tb_leftOperand.Location = new System.Drawing.Point(283, 26);
            this.tb_leftOperand.Name = "tb_leftOperand";
            this.tb_leftOperand.Size = new System.Drawing.Size(389, 20);
            this.tb_leftOperand.TabIndex = 1;
            // 
            // tb_rightOperand
            // 
            this.tb_rightOperand.Location = new System.Drawing.Point(283, 59);
            this.tb_rightOperand.Name = "tb_rightOperand";
            this.tb_rightOperand.Size = new System.Drawing.Size(389, 20);
            this.tb_rightOperand.TabIndex = 2;
            // 
            // tb_result
            // 
            this.tb_result.Location = new System.Drawing.Point(283, 98);
            this.tb_result.Name = "tb_result";
            this.tb_result.Size = new System.Drawing.Size(389, 20);
            this.tb_result.TabIndex = 3;
            // 
            // lb_line
            // 
            this.lb_line.AutoSize = true;
            this.lb_line.Location = new System.Drawing.Point(218, 82);
            this.lb_line.Name = "lb_line";
            this.lb_line.Size = new System.Drawing.Size(454, 13);
            this.lb_line.TabIndex = 4;
            this.lb_line.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------";
            // 
            // bt_calculate
            // 
            this.bt_calculate.Location = new System.Drawing.Point(164, 142);
            this.bt_calculate.Name = "bt_calculate";
            this.bt_calculate.Size = new System.Drawing.Size(93, 34);
            this.bt_calculate.TabIndex = 5;
            this.bt_calculate.Text = "Calculate";
            this.bt_calculate.UseVisualStyleBackColor = true;
            this.bt_calculate.Click += new System.EventHandler(this.bt_calculate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Numeral system";
            // 
            // tb_numeralSystem
            // 
            this.tb_numeralSystem.Location = new System.Drawing.Point(68, 163);
            this.tb_numeralSystem.Name = "tb_numeralSystem";
            this.tb_numeralSystem.Size = new System.Drawing.Size(25, 20);
            this.tb_numeralSystem.TabIndex = 7;
            this.tb_numeralSystem.Text = "10";
            // 
            // tb_leftSign
            // 
            this.tb_leftSign.Location = new System.Drawing.Point(242, 26);
            this.tb_leftSign.Name = "tb_leftSign";
            this.tb_leftSign.Size = new System.Drawing.Size(35, 20);
            this.tb_leftSign.TabIndex = 8;
            this.tb_leftSign.Text = "+";
            // 
            // tb_rightSign
            // 
            this.tb_rightSign.Location = new System.Drawing.Point(242, 59);
            this.tb_rightSign.Name = "tb_rightSign";
            this.tb_rightSign.Size = new System.Drawing.Size(35, 20);
            this.tb_rightSign.TabIndex = 9;
            this.tb_rightSign.Text = "+";
            // 
            // tb_resultSign
            // 
            this.tb_resultSign.Location = new System.Drawing.Point(242, 98);
            this.tb_resultSign.Name = "tb_resultSign";
            this.tb_resultSign.Size = new System.Drawing.Size(35, 20);
            this.tb_resultSign.TabIndex = 10;
            this.tb_resultSign.Text = "+";
            // 
            // lb_sign
            // 
            this.lb_sign.AutoSize = true;
            this.lb_sign.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_sign.Location = new System.Drawing.Point(199, 46);
            this.lb_sign.Name = "lb_sign";
            this.lb_sign.Size = new System.Drawing.Size(0, 20);
            this.lb_sign.TabIndex = 11;
            // 
            // lb_runningTime
            // 
            this.lb_runningTime.AutoSize = true;
            this.lb_runningTime.Location = new System.Drawing.Point(334, 143);
            this.lb_runningTime.Name = "lb_runningTime";
            this.lb_runningTime.Size = new System.Drawing.Size(0, 13);
            this.lb_runningTime.TabIndex = 12;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 188);
            this.Controls.Add(this.lb_runningTime);
            this.Controls.Add(this.lb_sign);
            this.Controls.Add(this.tb_resultSign);
            this.Controls.Add(this.tb_rightSign);
            this.Controls.Add(this.tb_leftSign);
            this.Controls.Add(this.tb_numeralSystem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_calculate);
            this.Controls.Add(this.lb_line);
            this.Controls.Add(this.tb_result);
            this.Controls.Add(this.tb_rightOperand);
            this.Controls.Add(this.tb_leftOperand);
            this.Controls.Add(this.gb_operations);
            this.Name = "FormMain";
            this.Text = "Arbitrary-precision arithmetic";
            this.gb_operations.ResumeLayout(false);
            this.gb_operations.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_operations;
        private System.Windows.Forms.RadioButton rb_addition;
        private System.Windows.Forms.TextBox tb_leftOperand;
        private System.Windows.Forms.TextBox tb_rightOperand;
        private System.Windows.Forms.TextBox tb_result;
        private System.Windows.Forms.Label lb_line;
        private System.Windows.Forms.Button bt_calculate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_numeralSystem;
        private System.Windows.Forms.RadioButton rb_multiplication;
        private System.Windows.Forms.RadioButton rb_dividing;
        private System.Windows.Forms.TextBox tb_leftSign;
        private System.Windows.Forms.TextBox tb_rightSign;
        private System.Windows.Forms.TextBox tb_resultSign;
        private System.Windows.Forms.RadioButton rb_karatsubaMultiplication;
        private System.Windows.Forms.Label lb_sign;
        private System.Windows.Forms.Label lb_runningTime;
    }
}


namespace LexicalAnaylzerRexton
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.codebox1 = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.LexTabPage = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.SyntaxTabPage = new System.Windows.Forms.TabPage();
            this.treeView = new System.Windows.Forms.TreeView();
            this.SemTabPage = new System.Windows.Forms.TabPage();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.z_var_scope = new System.Windows.Forms.Label();
            this.z_var_name = new System.Windows.Forms.Label();
            this.z_var_type = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.z_member_totalvar = new System.Windows.Forms.Label();
            this.z_member_category = new System.Windows.Forms.Label();
            this.z_members_params = new System.Windows.Forms.Label();
            this.z_member_name = new System.Windows.Forms.Label();
            this.z_member_type = new System.Windows.Forms.Label();
            this.z_member_access = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.z_class_totalmembers = new System.Windows.Forms.Label();
            this.z_class_parent = new System.Windows.Forms.Label();
            this.z_class_name = new System.Windows.Forms.Label();
            this.z_class_access = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.semanticTreeView = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.variables_data = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.member_data = new System.Windows.Forms.ComboBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.classes_data = new System.Windows.Forms.ComboBox();
            this.ICGTabPage = new System.Windows.Forms.TabPage();
            this.ICG_text = new System.Windows.Forms.RichTextBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.NotificationTabPage = new System.Windows.Forms.TabPage();
            this.mainLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sementicErrorLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lexicalErrorLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.syntaxErrorLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.totLineLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.totWordsLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.totalTokenLabel = new System.Windows.Forms.Label();
            this.characterCountLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ErrorTabPage = new System.Windows.Forms.TabPage();
            this.errorTextBox = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.LexTabPage.SuspendLayout();
            this.SyntaxTabPage.SuspendLayout();
            this.SemTabPage.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.ICGTabPage.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.NotificationTabPage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.ErrorTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // codebox1
            // 
            this.codebox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.codebox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codebox1.DetectUrls = false;
            this.codebox1.Font = new System.Drawing.Font("Consolas", 12F);
            this.codebox1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.codebox1.Location = new System.Drawing.Point(653, 40);
            this.codebox1.Name = "codebox1";
            this.codebox1.Size = new System.Drawing.Size(343, 376);
            this.codebox1.TabIndex = 1;
            this.codebox1.Text = "class program {\npublic static void main(){\naur_int a = 10;\naur_bool flag = false;" +
    "\nagar(a == 10 && !flag){\n++a;\na++;\n}\n}\n}\n\n";
            this.codebox1.TextChanged += new System.EventHandler(this.codebox1_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(653, 422);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(343, 49);
            this.button2.TabIndex = 3;
            this.button2.Text = "COMPILE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.BulletIndent = 1;
            this.richTextBox1.DetectUrls = false;
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(6, 20);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(615, 346);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.LexTabPage);
            this.tabControl1.Controls.Add(this.SyntaxTabPage);
            this.tabControl1.Controls.Add(this.SemTabPage);
            this.tabControl1.Controls.Add(this.ICGTabPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 51);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(635, 398);
            this.tabControl1.TabIndex = 7;
            // 
            // LexTabPage
            // 
            this.LexTabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LexTabPage.Controls.Add(this.label6);
            this.LexTabPage.Controls.Add(this.richTextBox1);
            this.LexTabPage.Location = new System.Drawing.Point(4, 22);
            this.LexTabPage.Name = "LexTabPage";
            this.LexTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.LexTabPage.Size = new System.Drawing.Size(627, 372);
            this.LexTabPage.TabIndex = 0;
            this.LexTabPage.Text = "Lexical Analyzer";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Tokens:";
            // 
            // SyntaxTabPage
            // 
            this.SyntaxTabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SyntaxTabPage.Controls.Add(this.treeView);
            this.SyntaxTabPage.Location = new System.Drawing.Point(4, 22);
            this.SyntaxTabPage.Name = "SyntaxTabPage";
            this.SyntaxTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SyntaxTabPage.Size = new System.Drawing.Size(627, 372);
            this.SyntaxTabPage.TabIndex = 1;
            this.SyntaxTabPage.Text = "Syntax Analyzer";
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(6, 6);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(615, 360);
            this.treeView.TabIndex = 0;
            // 
            // SemTabPage
            // 
            this.SemTabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SemTabPage.Controls.Add(this.groupBox13);
            this.SemTabPage.Controls.Add(this.groupBox14);
            this.SemTabPage.Controls.Add(this.groupBox12);
            this.SemTabPage.Controls.Add(this.semanticTreeView);
            this.SemTabPage.Controls.Add(this.groupBox2);
            this.SemTabPage.Controls.Add(this.groupBox1);
            this.SemTabPage.Controls.Add(this.groupBox8);
            this.SemTabPage.Location = new System.Drawing.Point(4, 22);
            this.SemTabPage.Name = "SemTabPage";
            this.SemTabPage.Size = new System.Drawing.Size(627, 372);
            this.SemTabPage.TabIndex = 2;
            this.SemTabPage.Text = "Sementic Analyzer";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.z_var_scope);
            this.groupBox13.Controls.Add(this.z_var_name);
            this.groupBox13.Controls.Add(this.z_var_type);
            this.groupBox13.Controls.Add(this.label21);
            this.groupBox13.Controls.Add(this.label22);
            this.groupBox13.Controls.Add(this.label23);
            this.groupBox13.Location = new System.Drawing.Point(6, 298);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(615, 71);
            this.groupBox13.TabIndex = 10;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Variable Data";
            // 
            // z_var_scope
            // 
            this.z_var_scope.AutoSize = true;
            this.z_var_scope.Location = new System.Drawing.Point(349, 19);
            this.z_var_scope.Name = "z_var_scope";
            this.z_var_scope.Size = new System.Drawing.Size(10, 13);
            this.z_var_scope.TabIndex = 12;
            this.z_var_scope.Text = ".";
            // 
            // z_var_name
            // 
            this.z_var_name.AutoSize = true;
            this.z_var_name.Location = new System.Drawing.Point(89, 19);
            this.z_var_name.Name = "z_var_name";
            this.z_var_name.Size = new System.Drawing.Size(10, 13);
            this.z_var_name.TabIndex = 10;
            this.z_var_name.Text = ".";
            // 
            // z_var_type
            // 
            this.z_var_type.AutoSize = true;
            this.z_var_type.Location = new System.Drawing.Point(44, 43);
            this.z_var_type.Name = "z_var_type";
            this.z_var_type.Size = new System.Drawing.Size(10, 13);
            this.z_var_type.TabIndex = 11;
            this.z_var_type.Text = ".";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(305, 19);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(38, 13);
            this.label21.TabIndex = 9;
            this.label21.Text = "Scope";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(7, 19);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(76, 13);
            this.label22.TabIndex = 7;
            this.label22.Text = "Variable Name";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(7, 43);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(31, 13);
            this.label23.TabIndex = 8;
            this.label23.Text = "Type";
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.z_member_totalvar);
            this.groupBox14.Controls.Add(this.z_member_category);
            this.groupBox14.Controls.Add(this.z_members_params);
            this.groupBox14.Controls.Add(this.z_member_name);
            this.groupBox14.Controls.Add(this.z_member_type);
            this.groupBox14.Controls.Add(this.z_member_access);
            this.groupBox14.Controls.Add(this.label19);
            this.groupBox14.Controls.Add(this.label20);
            this.groupBox14.Controls.Add(this.label15);
            this.groupBox14.Controls.Add(this.label17);
            this.groupBox14.Controls.Add(this.label16);
            this.groupBox14.Controls.Add(this.label18);
            this.groupBox14.Location = new System.Drawing.Point(304, 178);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(317, 114);
            this.groupBox14.TabIndex = 9;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Member Data";
            // 
            // z_member_totalvar
            // 
            this.z_member_totalvar.AutoSize = true;
            this.z_member_totalvar.Location = new System.Drawing.Point(239, 40);
            this.z_member_totalvar.Name = "z_member_totalvar";
            this.z_member_totalvar.Size = new System.Drawing.Size(10, 13);
            this.z_member_totalvar.TabIndex = 18;
            this.z_member_totalvar.Text = ".";
            // 
            // z_member_category
            // 
            this.z_member_category.AutoSize = true;
            this.z_member_category.Location = new System.Drawing.Point(211, 14);
            this.z_member_category.Name = "z_member_category";
            this.z_member_category.Size = new System.Drawing.Size(10, 13);
            this.z_member_category.TabIndex = 17;
            this.z_member_category.Text = ".";
            // 
            // z_members_params
            // 
            this.z_members_params.AutoSize = true;
            this.z_members_params.Location = new System.Drawing.Point(56, 91);
            this.z_members_params.Name = "z_members_params";
            this.z_members_params.Size = new System.Drawing.Size(10, 13);
            this.z_members_params.TabIndex = 16;
            this.z_members_params.Text = ".";
            // 
            // z_member_name
            // 
            this.z_member_name.AutoSize = true;
            this.z_member_name.Location = new System.Drawing.Point(76, 16);
            this.z_member_name.Name = "z_member_name";
            this.z_member_name.Size = new System.Drawing.Size(10, 13);
            this.z_member_name.TabIndex = 13;
            this.z_member_name.Text = ".";
            // 
            // z_member_type
            // 
            this.z_member_type.AutoSize = true;
            this.z_member_type.Location = new System.Drawing.Point(45, 65);
            this.z_member_type.Name = "z_member_type";
            this.z_member_type.Size = new System.Drawing.Size(10, 13);
            this.z_member_type.TabIndex = 15;
            this.z_member_type.Text = ".";
            // 
            // z_member_access
            // 
            this.z_member_access.AutoSize = true;
            this.z_member_access.Location = new System.Drawing.Point(95, 40);
            this.z_member_access.Name = "z_member_access";
            this.z_member_access.Size = new System.Drawing.Size(10, 13);
            this.z_member_access.TabIndex = 14;
            this.z_member_access.Text = ".";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(156, 40);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 13);
            this.label19.TabIndex = 12;
            this.label19.Text = "Total Variables";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(156, 14);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(49, 13);
            this.label20.TabIndex = 11;
            this.label20.Text = "Category";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 91);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "Params";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 13);
            this.label17.TabIndex = 7;
            this.label17.Text = "Class Name";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 65);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(31, 13);
            this.label16.TabIndex = 9;
            this.label16.Text = "Type";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 40);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 13);
            this.label18.TabIndex = 8;
            this.label18.Text = "Access Modifier";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.z_class_totalmembers);
            this.groupBox12.Controls.Add(this.z_class_parent);
            this.groupBox12.Controls.Add(this.z_class_name);
            this.groupBox12.Controls.Add(this.z_class_access);
            this.groupBox12.Controls.Add(this.label14);
            this.groupBox12.Controls.Add(this.label8);
            this.groupBox12.Controls.Add(this.label13);
            this.groupBox12.Controls.Add(this.label9);
            this.groupBox12.Location = new System.Drawing.Point(6, 177);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(292, 115);
            this.groupBox12.TabIndex = 8;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Class Data";
            // 
            // z_class_totalmembers
            // 
            this.z_class_totalmembers.AutoSize = true;
            this.z_class_totalmembers.Location = new System.Drawing.Point(90, 91);
            this.z_class_totalmembers.Name = "z_class_totalmembers";
            this.z_class_totalmembers.Size = new System.Drawing.Size(10, 13);
            this.z_class_totalmembers.TabIndex = 10;
            this.z_class_totalmembers.Text = ".";
            // 
            // z_class_parent
            // 
            this.z_class_parent.AutoSize = true;
            this.z_class_parent.Location = new System.Drawing.Point(79, 69);
            this.z_class_parent.Name = "z_class_parent";
            this.z_class_parent.Size = new System.Drawing.Size(10, 13);
            this.z_class_parent.TabIndex = 9;
            this.z_class_parent.Text = ".";
            // 
            // z_class_name
            // 
            this.z_class_name.AutoSize = true;
            this.z_class_name.Location = new System.Drawing.Point(75, 20);
            this.z_class_name.Name = "z_class_name";
            this.z_class_name.Size = new System.Drawing.Size(10, 13);
            this.z_class_name.TabIndex = 7;
            this.z_class_name.Text = ".";
            // 
            // z_class_access
            // 
            this.z_class_access.AutoSize = true;
            this.z_class_access.Location = new System.Drawing.Point(94, 44);
            this.z_class_access.Name = "z_class_access";
            this.z_class_access.Size = new System.Drawing.Size(10, 13);
            this.z_class_access.TabIndex = 8;
            this.z_class_access.Text = ".";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Total Members";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Parent Class";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Class Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Access Modifier";
            // 
            // semanticTreeView
            // 
            this.semanticTreeView.Location = new System.Drawing.Point(207, 4);
            this.semanticTreeView.Name = "semanticTreeView";
            this.semanticTreeView.Size = new System.Drawing.Size(414, 167);
            this.semanticTreeView.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.variables_data);
            this.groupBox2.Location = new System.Drawing.Point(6, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 52);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Variables";
            // 
            // variables_data
            // 
            this.variables_data.FormattingEnabled = true;
            this.variables_data.Location = new System.Drawing.Point(6, 19);
            this.variables_data.Name = "variables_data";
            this.variables_data.Size = new System.Drawing.Size(183, 21);
            this.variables_data.TabIndex = 0;
            this.variables_data.Text = "Select a Class";
            this.variables_data.SelectedIndexChanged += new System.EventHandler(this.variables_data_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.member_data);
            this.groupBox1.Location = new System.Drawing.Point(6, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 52);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Members";
            // 
            // member_data
            // 
            this.member_data.FormattingEnabled = true;
            this.member_data.Location = new System.Drawing.Point(6, 19);
            this.member_data.Name = "member_data";
            this.member_data.Size = new System.Drawing.Size(183, 21);
            this.member_data.TabIndex = 0;
            this.member_data.Text = "Select a Class";
            this.member_data.SelectedIndexChanged += new System.EventHandler(this.member_data_SelectedIndexChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.classes_data);
            this.groupBox8.Location = new System.Drawing.Point(6, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(195, 52);
            this.groupBox8.TabIndex = 3;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Classes";
            // 
            // classes_data
            // 
            this.classes_data.FormattingEnabled = true;
            this.classes_data.Location = new System.Drawing.Point(6, 19);
            this.classes_data.Name = "classes_data";
            this.classes_data.Size = new System.Drawing.Size(183, 21);
            this.classes_data.TabIndex = 0;
            this.classes_data.Text = "Select a Class";
            this.classes_data.SelectedIndexChanged += new System.EventHandler(this.classes_data_SelectedIndexChanged);
            // 
            // ICGTabPage
            // 
            this.ICGTabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ICGTabPage.Controls.Add(this.ICG_text);
            this.ICGTabPage.Location = new System.Drawing.Point(4, 22);
            this.ICGTabPage.Name = "ICGTabPage";
            this.ICGTabPage.Size = new System.Drawing.Size(627, 372);
            this.ICGTabPage.TabIndex = 3;
            this.ICGTabPage.Text = "ICG";
            // 
            // ICG_text
            // 
            this.ICG_text.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ICG_text.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ICG_text.ForeColor = System.Drawing.Color.OrangeRed;
            this.ICG_text.Location = new System.Drawing.Point(3, 3);
            this.ICG_text.Name = "ICG_text";
            this.ICG_text.Size = new System.Drawing.Size(621, 366);
            this.ICG_text.TabIndex = 0;
            this.ICG_text.Text = "ICG CODE:";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.NotificationTabPage);
            this.tabControl2.Controls.Add(this.ErrorTabPage);
            this.tabControl2.Location = new System.Drawing.Point(12, 455);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(984, 131);
            this.tabControl2.TabIndex = 8;
            // 
            // NotificationTabPage
            // 
            this.NotificationTabPage.Controls.Add(this.mainLabel);
            this.NotificationTabPage.Controls.Add(this.panel1);
            this.NotificationTabPage.Controls.Add(this.totLineLabel);
            this.NotificationTabPage.Controls.Add(this.label12);
            this.NotificationTabPage.Controls.Add(this.totWordsLabel);
            this.NotificationTabPage.Controls.Add(this.label10);
            this.NotificationTabPage.Controls.Add(this.totalTokenLabel);
            this.NotificationTabPage.Controls.Add(this.characterCountLabel);
            this.NotificationTabPage.Controls.Add(this.label7);
            this.NotificationTabPage.Controls.Add(this.label1);
            this.NotificationTabPage.Location = new System.Drawing.Point(4, 22);
            this.NotificationTabPage.Name = "NotificationTabPage";
            this.NotificationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.NotificationTabPage.Size = new System.Drawing.Size(976, 105);
            this.NotificationTabPage.TabIndex = 0;
            this.NotificationTabPage.Text = "Notifications";
            this.NotificationTabPage.UseVisualStyleBackColor = true;
            // 
            // mainLabel
            // 
            this.mainLabel.AutoSize = true;
            this.mainLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabel.ForeColor = System.Drawing.Color.Maroon;
            this.mainLabel.Location = new System.Drawing.Point(725, 12);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(91, 15);
            this.mainLabel.TabIndex = 15;
            this.mainLabel.Text = "No Main Found";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sementicErrorLabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lexicalErrorLabel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.syntaxErrorLabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(637, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 71);
            this.panel1.TabIndex = 14;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // sementicErrorLabel
            // 
            this.sementicErrorLabel.AutoSize = true;
            this.sementicErrorLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sementicErrorLabel.ForeColor = System.Drawing.Color.Green;
            this.sementicErrorLabel.Location = new System.Drawing.Point(88, 44);
            this.sementicErrorLabel.Name = "sementicErrorLabel";
            this.sementicErrorLabel.Size = new System.Drawing.Size(53, 15);
            this.sementicErrorLabel.TabIndex = 13;
            this.sementicErrorLabel.Text = "No Error";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Syntax:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lexicalErrorLabel
            // 
            this.lexicalErrorLabel.AutoSize = true;
            this.lexicalErrorLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lexicalErrorLabel.ForeColor = System.Drawing.Color.Green;
            this.lexicalErrorLabel.Location = new System.Drawing.Point(88, 8);
            this.lexicalErrorLabel.Name = "lexicalErrorLabel";
            this.lexicalErrorLabel.Size = new System.Drawing.Size(53, 15);
            this.lexicalErrorLabel.TabIndex = 11;
            this.lexicalErrorLabel.Text = "No Error";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Sementic:";
            // 
            // syntaxErrorLabel
            // 
            this.syntaxErrorLabel.AutoSize = true;
            this.syntaxErrorLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.syntaxErrorLabel.ForeColor = System.Drawing.Color.Green;
            this.syntaxErrorLabel.Location = new System.Drawing.Point(88, 26);
            this.syntaxErrorLabel.Name = "syntaxErrorLabel";
            this.syntaxErrorLabel.Size = new System.Drawing.Size(53, 15);
            this.syntaxErrorLabel.TabIndex = 12;
            this.syntaxErrorLabel.Text = "No Error";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Lexical:";
            // 
            // totLineLabel
            // 
            this.totLineLabel.AutoSize = true;
            this.totLineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totLineLabel.Location = new System.Drawing.Point(116, 77);
            this.totLineLabel.Name = "totLineLabel";
            this.totLineLabel.Size = new System.Drawing.Size(15, 16);
            this.totLineLabel.TabIndex = 7;
            this.totLineLabel.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 16);
            this.label12.TabIndex = 6;
            this.label12.Text = "Total Line:";
            // 
            // totWordsLabel
            // 
            this.totWordsLabel.AutoSize = true;
            this.totWordsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totWordsLabel.Location = new System.Drawing.Point(116, 55);
            this.totWordsLabel.Name = "totWordsLabel";
            this.totWordsLabel.Size = new System.Drawing.Size(15, 16);
            this.totWordsLabel.TabIndex = 5;
            this.totWordsLabel.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 16);
            this.label10.TabIndex = 4;
            this.label10.Text = "Total Words:";
            // 
            // totalTokenLabel
            // 
            this.totalTokenLabel.AutoSize = true;
            this.totalTokenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTokenLabel.Location = new System.Drawing.Point(116, 33);
            this.totalTokenLabel.Name = "totalTokenLabel";
            this.totalTokenLabel.Size = new System.Drawing.Size(15, 16);
            this.totalTokenLabel.TabIndex = 3;
            this.totalTokenLabel.Text = "0";
            // 
            // characterCountLabel
            // 
            this.characterCountLabel.AutoSize = true;
            this.characterCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.characterCountLabel.Location = new System.Drawing.Point(115, 12);
            this.characterCountLabel.Name = "characterCountLabel";
            this.characterCountLabel.Size = new System.Drawing.Size(15, 16);
            this.characterCountLabel.TabIndex = 2;
            this.characterCountLabel.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Total Token Set:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Characters Count:";
            // 
            // ErrorTabPage
            // 
            this.ErrorTabPage.BackColor = System.Drawing.Color.Black;
            this.ErrorTabPage.Controls.Add(this.errorTextBox);
            this.ErrorTabPage.ForeColor = System.Drawing.Color.Gold;
            this.ErrorTabPage.Location = new System.Drawing.Point(4, 22);
            this.ErrorTabPage.Name = "ErrorTabPage";
            this.ErrorTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ErrorTabPage.Size = new System.Drawing.Size(976, 105);
            this.ErrorTabPage.TabIndex = 1;
            this.ErrorTabPage.Text = "Error";
            // 
            // errorTextBox
            // 
            this.errorTextBox.BackColor = System.Drawing.SystemColors.WindowText;
            this.errorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorTextBox.ForeColor = System.Drawing.Color.Red;
            this.errorTextBox.Location = new System.Drawing.Point(0, 0);
            this.errorTextBox.Name = "errorTextBox";
            this.errorTextBox.Size = new System.Drawing.Size(976, 106);
            this.errorTextBox.TabIndex = 0;
            this.errorTextBox.Text = "Errors:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(650, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Source Code:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(65, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(42, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Save Token";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(550, 23);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(87, 22);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Live View";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 595);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.codebox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Rexton Compiler";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.LexTabPage.ResumeLayout(false);
            this.LexTabPage.PerformLayout();
            this.SyntaxTabPage.ResumeLayout(false);
            this.SemTabPage.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.ICGTabPage.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.NotificationTabPage.ResumeLayout(false);
            this.NotificationTabPage.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ErrorTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox codebox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage LexTabPage;
        private System.Windows.Forms.TabPage SyntaxTabPage;
        private System.Windows.Forms.TabPage SemTabPage;
        private System.Windows.Forms.TabPage ICGTabPage;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage NotificationTabPage;
        private System.Windows.Forms.TabPage ErrorTabPage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label totalTokenLabel;
        private System.Windows.Forms.Label characterCountLabel;
        private System.Windows.Forms.Label totLineLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label totWordsLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label sementicErrorLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label syntaxErrorLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lexicalErrorLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox errorTextBox;
        public System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox variables_data;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox member_data;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ComboBox classes_data;
        public System.Windows.Forms.TreeView semanticTreeView;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Label z_var_scope;
        private System.Windows.Forms.Label z_var_name;
        private System.Windows.Forms.Label z_var_type;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Label z_member_totalvar;
        private System.Windows.Forms.Label z_member_category;
        private System.Windows.Forms.Label z_members_params;
        private System.Windows.Forms.Label z_member_name;
        private System.Windows.Forms.Label z_member_type;
        private System.Windows.Forms.Label z_member_access;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Label z_class_totalmembers;
        private System.Windows.Forms.Label z_class_parent;
        private System.Windows.Forms.Label z_class_name;
        private System.Windows.Forms.Label z_class_access;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.RichTextBox ICG_text;
        private System.Windows.Forms.Label mainLabel;
    }
}


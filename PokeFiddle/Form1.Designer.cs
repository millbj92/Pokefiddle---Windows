namespace PokeFiddle
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
            this.mMap = new GMap.NET.WindowsForms.GMapControl();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cbPokemon = new System.Windows.Forms.CheckBox();
            this.cbPokestops = new System.Windows.Forms.CheckBox();
            this.cbGyms = new System.Windows.Forms.CheckBox();
            this.nudIterations = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.longText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.latText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.currentLatLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.currentLonLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.locateBtn = new System.Windows.Forms.Button();
            this.pokemonList = new System.Windows.Forms.CheckedListBox();
            this.selectAllLbl = new System.Windows.Forms.LinkLabel();
            this.deselectLbl = new System.Windows.Forms.LinkLabel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.redCheckBox = new System.Windows.Forms.CheckBox();
            this.blueCheckBox = new System.Windows.Forms.CheckBox();
            this.yellowCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // mMap
            // 
            this.mMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mMap.AutoSize = true;
            this.mMap.Bearing = 0F;
            this.mMap.CanDragMap = true;
            this.mMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.mMap.GrayScaleMode = false;
            this.mMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.mMap.LevelsKeepInMemmory = 5;
            this.mMap.Location = new System.Drawing.Point(379, 22);
            this.mMap.MarkersEnabled = true;
            this.mMap.MaxZoom = 2;
            this.mMap.MinZoom = 2;
            this.mMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.mMap.Name = "mMap";
            this.mMap.NegativeMode = false;
            this.mMap.PolygonsEnabled = true;
            this.mMap.RetryLoadTile = 0;
            this.mMap.RoutesEnabled = true;
            this.mMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.mMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.mMap.ShowTileGridLines = false;
            this.mMap.Size = new System.Drawing.Size(896, 759);
            this.mMap.TabIndex = 0;
            this.mMap.Zoom = 0D;
            this.mMap.Click += new System.EventHandler(this.mMap_Click);
            this.mMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mMap_MouseClick);
            this.mMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mMap_MouseMove);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(99, 224);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(269, 26);
            this.txtUser.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(99, 256);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(269, 26);
            this.txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(10, 705);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(356, 29);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Start";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Poke Trainer Club",
            "Google"});
            this.comboBox1.Location = new System.Drawing.Point(12, 126);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(354, 28);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Text = "Login Type";
            // 
            // cbPokemon
            // 
            this.cbPokemon.AutoSize = true;
            this.cbPokemon.Checked = true;
            this.cbPokemon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPokemon.Location = new System.Drawing.Point(12, 675);
            this.cbPokemon.Name = "cbPokemon";
            this.cbPokemon.Size = new System.Drawing.Size(102, 24);
            this.cbPokemon.TabIndex = 7;
            this.cbPokemon.Text = "Pokemon";
            this.cbPokemon.UseVisualStyleBackColor = true;
            this.cbPokemon.CheckedChanged += new System.EventHandler(this.cbPokemon_CheckedChanged);
            // 
            // cbPokestops
            // 
            this.cbPokestops.AutoSize = true;
            this.cbPokestops.Checked = true;
            this.cbPokestops.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPokestops.Location = new System.Drawing.Point(132, 675);
            this.cbPokestops.Name = "cbPokestops";
            this.cbPokestops.Size = new System.Drawing.Size(110, 24);
            this.cbPokestops.TabIndex = 8;
            this.cbPokestops.Text = "Pokestops";
            this.cbPokestops.UseVisualStyleBackColor = true;
            this.cbPokestops.CheckedChanged += new System.EventHandler(this.cbPokestops_CheckedChanged);
            // 
            // cbGyms
            // 
            this.cbGyms.AutoSize = true;
            this.cbGyms.Checked = true;
            this.cbGyms.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbGyms.Location = new System.Drawing.Point(248, 675);
            this.cbGyms.Name = "cbGyms";
            this.cbGyms.Size = new System.Drawing.Size(76, 24);
            this.cbGyms.TabIndex = 9;
            this.cbGyms.Text = "Gyms";
            this.cbGyms.UseVisualStyleBackColor = true;
            this.cbGyms.CheckedChanged += new System.EventHandler(this.cbGyms_CheckedChanged);
            // 
            // nudIterations
            // 
            this.nudIterations.Location = new System.Drawing.Point(132, 288);
            this.nudIterations.Name = "nudIterations";
            this.nudIterations.Size = new System.Drawing.Size(234, 26);
            this.nudIterations.TabIndex = 10;
            this.nudIterations.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudIterations.ValueChanged += new System.EventHandler(this.nudIterations_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Move Iterations";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 4;
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numericUpDown1.Location = new System.Drawing.Point(132, 321);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(234, 26);
            this.numericUpDown1.TabIndex = 12;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            262144});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 321);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Precision";
            // 
            // longText
            // 
            this.longText.Location = new System.Drawing.Point(99, 192);
            this.longText.Name = "longText";
            this.longText.Size = new System.Drawing.Size(269, 26);
            this.longText.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Longitude";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Latitude";
            // 
            // latText
            // 
            this.latText.Location = new System.Drawing.Point(99, 160);
            this.latText.Name = "latText";
            this.latText.Size = new System.Drawing.Size(269, 26);
            this.latText.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Mouse Latitude:";
            // 
            // currentLatLabel
            // 
            this.currentLatLabel.AutoSize = true;
            this.currentLatLabel.Location = new System.Drawing.Point(148, 2);
            this.currentLatLabel.Name = "currentLatLabel";
            this.currentLatLabel.Size = new System.Drawing.Size(0, 20);
            this.currentLatLabel.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "Mouse Longitude:";
            // 
            // currentLonLabel
            // 
            this.currentLonLabel.AutoSize = true;
            this.currentLonLabel.Location = new System.Drawing.Point(161, 22);
            this.currentLonLabel.Name = "currentLonLabel";
            this.currentLonLabel.Size = new System.Drawing.Size(0, 20);
            this.currentLonLabel.TabIndex = 21;
            this.currentLonLabel.Click += new System.EventHandler(this.currentLonLabel_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(10, 740);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(356, 31);
            this.progressBar.TabIndex = 22;
            // 
            // locateBtn
            // 
            this.locateBtn.Image = global::PokeFiddle.Properties.Resources.locateIcon;
            this.locateBtn.Location = new System.Drawing.Point(12, 45);
            this.locateBtn.Name = "locateBtn";
            this.locateBtn.Size = new System.Drawing.Size(352, 75);
            this.locateBtn.TabIndex = 23;
            this.locateBtn.UseVisualStyleBackColor = true;
            this.locateBtn.Click += new System.EventHandler(this.locateBtn_Click);
            // 
            // pokemonList
            // 
            this.pokemonList.CheckOnClick = true;
            this.pokemonList.FormattingEnabled = true;
            this.pokemonList.Items.AddRange(new object[] {
            "Abra",
            "Aerodactyl",
            "Alakazam",
            "Arbok",
            "Arcanine",
            "Articuno",
            "Beedrill",
            "Bellsprout",
            "Blastoise",
            "Bulbasaur",
            "Butterfree",
            "Caterpie",
            "Chansey",
            "Charizard",
            "Charmander",
            "Charmeleon",
            "Clefable",
            "Clefairy",
            "Cloyster",
            "Cubone",
            "Dewgong",
            "Diglett",
            "Ditto",
            "Dodrio",
            "Doduo",
            "Dragonair",
            "Dragonite",
            "Dratini",
            "Drowzee",
            "Dugtrio",
            "Eevee",
            "Ekans",
            "Electabuzz",
            "Electrode",
            "Exeggcute",
            "Exeggutor",
            "Fearow",
            "Ferfetchd",
            "Flareon",
            "Gastly",
            "Gengar",
            "Geodude",
            "Gloom",
            "Golbat",
            "Goldeen",
            "Golduck",
            "Golem",
            "Graveler",
            "Grimer",
            "Growlithe",
            "Gyrados",
            "Haunter",
            "Hitmonchan",
            "Hitmonlee",
            "Horsea",
            "Hypno",
            "Ivysaur",
            "Jigglepuff",
            "Jolteon",
            "Jynx",
            "Kabuto",
            "Kabutops",
            "Kadabra",
            "Kakuna",
            "Kanhaskhan",
            "Kingler",
            "Koffing",
            "Krabby",
            "Lapras",
            "Lickitung",
            "Machamp",
            "Machoke",
            "Machop",
            "Magikarp",
            "Magmar",
            "Magnemite",
            "Magneton",
            "Mankey",
            "Marowak",
            "Meowth",
            "Metapod",
            "Mew",
            "Mewtwo",
            "Moltres",
            "MrMime",
            "Muk",
            "Nidoking",
            "Nidoqueen",
            "NidoranFemale",
            "NidoranMale",
            "Nidorina",
            "Nidorino",
            "Ninetales",
            "Oddish",
            "Omanyte",
            "Omastar",
            "Onix",
            "Paras",
            "Parasect",
            "Persian",
            "Pidgeot",
            "Pidgeotto",
            "Pidgey",
            "Pikachu",
            "Pinsir",
            "Poliwag",
            "Poliwhirl",
            "Poliwrath",
            "Ponyta",
            "Porygon",
            "Primeape",
            "Psyduck",
            "Raichu",
            "Rapidash",
            "Raticate",
            "Rattata",
            "Rhydon",
            "Rhyhorn",
            "Sandshrew",
            "Sandslash",
            "Scyther",
            "Seadra",
            "Seaking",
            "Seel",
            "Shellder",
            "Slowbro",
            "Slowpoke",
            "Snorlax",
            "Spearow",
            "Squirtle",
            "Starmie",
            "Staryu",
            "Tangela",
            "Tauros",
            "Tentacool",
            "Tentacruel",
            "Vaporeon",
            "Venomoth",
            "Venonat",
            "Venusaur",
            "Victreebell",
            "Vileplume",
            "Voltorb",
            "Vulpix",
            "Wartortle",
            "Weedle",
            "Weepinbell",
            "Weezing",
            "Wigglypuff",
            "Zapdos",
            "Zubat"});
            this.pokemonList.Location = new System.Drawing.Point(12, 359);
            this.pokemonList.Name = "pokemonList";
            this.pokemonList.Size = new System.Drawing.Size(352, 193);
            this.pokemonList.Sorted = true;
            this.pokemonList.TabIndex = 24;
            this.pokemonList.SelectedValueChanged += new System.EventHandler(this.pokemonList_SelectedValueChanged);
            // 
            // selectAllLbl
            // 
            this.selectAllLbl.AutoSize = true;
            this.selectAllLbl.Location = new System.Drawing.Point(12, 559);
            this.selectAllLbl.Name = "selectAllLbl";
            this.selectAllLbl.Size = new System.Drawing.Size(75, 20);
            this.selectAllLbl.TabIndex = 25;
            this.selectAllLbl.TabStop = true;
            this.selectAllLbl.Text = "Select All";
            this.selectAllLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.selectAllLbl_LinkClicked);
            // 
            // deselectLbl
            // 
            this.deselectLbl.AutoSize = true;
            this.deselectLbl.Location = new System.Drawing.Point(227, 559);
            this.deselectLbl.Name = "deselectLbl";
            this.deselectLbl.Size = new System.Drawing.Size(93, 20);
            this.deselectLbl.TabIndex = 26;
            this.deselectLbl.TabStop = true;
            this.deselectLbl.Text = "Deselect All";
            this.deselectLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.deselectLbl_LinkClicked);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(10, 602);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(225, 24);
            this.checkBox1.TabIndex = 27;
            this.checkBox1.Text = "Only Pokestops With Lures";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // redCheckBox
            // 
            this.redCheckBox.AutoSize = true;
            this.redCheckBox.Checked = true;
            this.redCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.redCheckBox.Location = new System.Drawing.Point(10, 645);
            this.redCheckBox.Name = "redCheckBox";
            this.redCheckBox.Size = new System.Drawing.Size(109, 24);
            this.redCheckBox.TabIndex = 28;
            this.redCheckBox.Text = "Red Team";
            this.redCheckBox.UseVisualStyleBackColor = true;
            this.redCheckBox.CheckedChanged += new System.EventHandler(this.redCheckBox_CheckedChanged);
            // 
            // blueCheckBox
            // 
            this.blueCheckBox.AutoSize = true;
            this.blueCheckBox.Checked = true;
            this.blueCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.blueCheckBox.Location = new System.Drawing.Point(132, 645);
            this.blueCheckBox.Name = "blueCheckBox";
            this.blueCheckBox.Size = new System.Drawing.Size(111, 24);
            this.blueCheckBox.TabIndex = 29;
            this.blueCheckBox.Text = "Blue Team";
            this.blueCheckBox.UseVisualStyleBackColor = true;
            this.blueCheckBox.CheckedChanged += new System.EventHandler(this.blueCheckBox_CheckedChanged);
            // 
            // yellowCheckBox
            // 
            this.yellowCheckBox.AutoSize = true;
            this.yellowCheckBox.Checked = true;
            this.yellowCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.yellowCheckBox.Location = new System.Drawing.Point(248, 644);
            this.yellowCheckBox.Name = "yellowCheckBox";
            this.yellowCheckBox.Size = new System.Drawing.Size(125, 24);
            this.yellowCheckBox.TabIndex = 30;
            this.yellowCheckBox.Text = "Yellow Team";
            this.yellowCheckBox.UseVisualStyleBackColor = true;
            this.yellowCheckBox.CheckedChanged += new System.EventHandler(this.yellowCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 783);
            this.Controls.Add(this.yellowCheckBox);
            this.Controls.Add(this.blueCheckBox);
            this.Controls.Add(this.redCheckBox);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.deselectLbl);
            this.Controls.Add(this.selectAllLbl);
            this.Controls.Add(this.pokemonList);
            this.Controls.Add(this.locateBtn);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.currentLonLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.currentLatLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.mMap);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.latText);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.cbPokemon);
            this.Controls.Add(this.nudIterations);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbPokestops);
            this.Controls.Add(this.cbGyms);
            this.Controls.Add(this.longText);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nudIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl mMap;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox cbPokemon;
        private System.Windows.Forms.CheckBox cbPokestops;
        private System.Windows.Forms.CheckBox cbGyms;
        private System.Windows.Forms.NumericUpDown nudIterations;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox longText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox latText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label currentLatLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label currentLonLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button locateBtn;
        private System.Windows.Forms.CheckedListBox pokemonList;
        private System.Windows.Forms.LinkLabel selectAllLbl;
        private System.Windows.Forms.LinkLabel deselectLbl;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox redCheckBox;
        private System.Windows.Forms.CheckBox blueCheckBox;
        private System.Windows.Forms.CheckBox yellowCheckBox;
    }
}


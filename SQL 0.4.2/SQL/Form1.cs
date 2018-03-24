using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.IO;
using System.Diagnostics;

namespace SQL
{
    public partial class Form1 : MetroForm
    {
        List<string> _items = new List<string>(); // 리스트

        public Form1()
        {
            InitializeComponent();
            _items.Add("INSERT INTO `shopitems` (`shopitemid`, `shopid`, `itemid`, `price`, `position`, `pricequantity`, `Tab`, `quantity`, `period`, `limititem`) VALUES"); // 메이커 실행후 리스트처음추가시 추가
        }

        //ADD ROW
        private void add(string shopitemids, String shopids, String itemids, String prices, String positions, String pricequantities, String tabs, String quatities, String periods, String limititems, String npcids)
        {
            //ARRAY TO REP A ROW
            String[] row = { shopitemids, shopids, itemids, prices, positions, pricequantities, tabs, quatities, periods, limititems, npcids };
            ListViewItem item = new ListViewItem(row);
            //ADD ITEMS
            listView1.Items.Add(item);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked) // 체크박스가 체크되있을때
            {
                // 추가버튼 클릭시
                _items.Add("(" + ShopItemId.Text + "." + ShopId.Text + "," + ItemId.Text + "," + Price.Text + "," + Position.Text + "," + PriceQuantity.Text + "," + Tab.Text + "," + Quantity.Text + "." + Period.Text + "," + LimitItem.Text + ");"); // 스트링 추가
                _items.Add("");
                _items.Add("INSERT INTO `shops` (`shopid`,`npcid`) VALUES");
                _items.Add("("+ShopId.Text+","+Npc.Text+");");
                // 데이터 수정
                listBox1.DataSource = null;
                listBox1.DataSource = _items;
                // 데이터 테이블에 추가
                add(ShopItemId.Text, ShopId.Text, ItemId.Text, Price.Text, Position.Text, PriceQuantity.Text, Tab.Text, Quantity.Text, Period.Text, LimitItem.Text, Npc.Text); //테이블 추가 메소드는 위에 string 으로 모두 처리하기
            }
            else if (!checkBox1.Checked) // 체크박스가 체크되지 않았을때
            {
                // 추가버튼 클릭시
                _items.Add("(" + ShopItemId.Text + "." + ShopId.Text + "," + ItemId.Text + "," + Price.Text + "," + Position.Text + "," + PriceQuantity.Text + "," + Tab.Text + "," + Quantity.Text + "." + Period.Text + "," + LimitItem.Text + "),"); // 스트링 추가
                // 데이터 수정
                listBox1.DataSource = null;
                listBox1.DataSource = _items;
                // 데이터 테이블에 추가
                add(ShopItemId.Text, ShopId.Text, ItemId.Text, Price.Text, Position.Text, PriceQuantity.Text, Tab.Text, Quantity.Text, Period.Text, LimitItem.Text, Npc.Text); //테이블 추가 메소드는 위에 string 으로 모두 처리하기

            }
        }

        private void Del_Click(object sender, EventArgs e)
        {
            // 삭제 버튼 클릭됨
            int selectedIndex = listBox1.SelectedIndex;

            try
            {
                // 라인 제거
                _items.RemoveAt(selectedIndex);
            }
            catch
            {
            }
            // 데이터 수정
            listBox1.DataSource = null;
            listBox1.DataSource = _items;
        }

        private void Restore_Click(object sender, EventArgs e)
        {
            FormClosed += (o, a) => new Form1().ShowDialog();

            Hide();
            Close();
            MessageBox.Show("재로딩 완료");
        }

        private void button1_Click(object sender, EventArgs e) // 쿼리 파일 저장
        {
            //MessageBox.Show("이 기능은 좀만 기다려");
            using (TextWriter TW = new StreamWriter(Title.Text + ".sql"))
            {
                foreach (string itemText in listBox1.Items)
                {
                    TW.WriteLine(itemText);
                }
            }
            MessageBox.Show("상점메이커경로에 저장되었습니다.");
            
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("이 프로그램은 C# 공부용으로 제작되었으며, 모든 저작권은 치 우 씨 한테있습니다.  Ver.021817 (테스트 버전 0.4.2)");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("이건 필요가없습니다. 그냥 하세요.");
        }
    }
}

using GenericApiNetCore.ClientLib;
using GenericApiNetCore.Samples.Entities;

namespace WinFormsAppTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Uri baseAddress = new Uri("https://localhost:7013/");
        int page = 1;

        private async void button1_Click(object sender, EventArgs e)
        {
            //page
            page = Math.Max(page - 1, 1);
            await _callMethod(nameof(PagingAsync), page);
        }

        private async Task _callMethod(string method, params object[] data)
        {
            var resultTask = this.GetType()
                  .GetMethod(method)?
                  .MakeGenericMethod(Entity)
                  .Invoke(this, data);
            if (resultTask is Task task)
            {
                await task;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //create
            await _callMethod(nameof(CreateAsync));
        }

        T UpdateData<T>(T data)
        {
            if (data is Product product)
            {
                product.Name = DateTime.Now.ToString();
            }
            else if (data is Client client)
            {
                client.Name = DateTime.Now.ToString();
            }
            return data;
        }

        Guid GetId<T>(T data)
        {
            if (data is Product product) return product.Id;
            if (data is Client client) return client.Id;
            return default;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            //update
            await _callMethod(nameof(UpdateAsync));
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            //delete
            await _callMethod(nameof(DeleteAsync));
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            //page
            page++;
            await _callMethod(nameof(PagingAsync), page);
        }

        Type Entity => comboBox1.SelectedItem as Type ?? typeof(Product);

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DisplayMember = nameof(Type.Name);
            comboBox1.Items.Add(typeof(Product));
            comboBox1.Items.Add(typeof(Client));
            comboBox1.SelectedIndex = 0;
        }

        public async Task<IApiResult<List<T>>> PagingAsync<T>(int page)
        {
            using var client = new ClientApiMethod<T>(baseAddress);
            var data = await client.PagingAsync(new PagingRequest<T>() { Payload = page });
            dataGridView1.DataSource = data.Result;
            Text = $"Page {page}";
            return data;
        }

        public async Task<IApiResult<List<T>>> CreateAsync<T>()
        {
            var newdata = new List<T> { Activator.CreateInstance<T>() };
            using var client = new ClientApiMethod<T>(baseAddress);
            var data = await client.CreateAsync(new CreateRequest<T>() { Payload = newdata });
            MessageBox.Show($"{data.IsSuccess} {data.Message}");
            return data;
        }

        public async Task<IApiResult<List<T>>> UpdateAsync<T>() where T : class
        {
            var newdata = dataGridView1.SelectedCells.Cast<DataGridViewCell>()
                .Select(q => dataGridView1.Rows[q.RowIndex].DataBoundItem as T)
                .Select(UpdateData).ToList();
            using var client = new ClientApiMethod<T>(baseAddress);
            var data = await client.UpdateAsync(new UpdateRequest<T>() { Payload = newdata });
            MessageBox.Show($"{data.IsSuccess} {data.Message}");
            return data;
        }

        public async Task<IApiResult<int>> DeleteAsync<T>() where T : class
        {
            var newdata = dataGridView1.SelectedCells.Cast<DataGridViewCell>()
                .Select(q => dataGridView1.Rows[q.RowIndex].DataBoundItem as T)
                .Select(GetId)
                .ToArray();
            using var client = new ClientApiMethod<T>(baseAddress);
            var data = await client.DeleteAsync(new DeleteRequest<T>() { Payload = newdata });
            MessageBox.Show($"{data.IsSuccess} {data.Message}");
            return data;
        }
    }
}
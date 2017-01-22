# MCS POS

Project MCS POS untuk Apotek Glodok Jakarta. Terdiri dari 2 aplikasi : aplikasi back office (MCS POS), aplikasi kasir (MCS POS.Kasir). Aplikasi back office dan aplikasi kasir membutuhkan library MCS POS.Model untuk berkomunikasi dengan database dengan memanfaatkan library Dapper versi .NET 4.0 agar bisa berjalan di Windows XP.

## ChangeLog

### MCS POS
#### Version 1.2.0 (initial versioning)
* Fitur **Master** sudah berjalan : Master Item, Master Supplier, Master Pelanggan, Master Satuan, Jenis, Bank, Gudang, Multi Satuan Konversi (Pak->Dus->Pcs) dll, Multi Harga Jual, Kartu Stok Barang
* Fitur **Pembelian** sudah berjalan : Pembelian, Retur Pembelian
* Fitur **Penjualan** sudah berjalan : Penjualan barang, Kasir (Point Of Sale)
* Fitur **Persediaan** sudah berjalan : Item Masuk, Item Keluar, Opname Stok, Transfer Gudang, Saldo Awal Item.
* Fitur **Proses Data** baru bisa berjalan yang Proses Bulanan secara parsial, belum bisa jalan untuk yang proses tahunan
* Fitur **Pengaturan** : User management dan pengaturan umum (untuk cetak struk)

### MCS POS.Kasir
#### Version 1.2.0 (initial versioning)
* Penjualan dengan retur sudah bisa
* Cetak sudah lancar

### MCS POS.Model
#### Version 1.3.0 (initial versioning)

## Kebutuhan Sistem
* Minimal MySQL 5.1
* .NET Framework 4.0

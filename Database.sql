CREATE TABLE IF NOT EXISTS barang 
(
	kode_barang INT PRIMARY KEY,
	nama_barang VARCHAR(50),
	harga_barang INT NOT NULL,
	jumlah_barang INT NOT NULL
);
INSERT INTO barang (kode_barang,nama_barang,harga_barang,jumlah_barang) VALUES (1,'kaos',30000,50);
INSERT INTO barang (kode_barang,nama_barang,harga_barang,jumlah_barang) VALUES (2,'kemeja',80000,50);
INSERT INTO barang (kode_barang,nama_barang,harga_barang,jumlah_barang) VALUES (3,'jas',150000,95);
INSERT INTO barang (kode_barang,nama_barang,harga_barang,jumlah_barang) VALUES (4,'hoodie',90000,80);
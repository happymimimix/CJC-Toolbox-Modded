   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   �   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   
.MainTitle  a.CJCAMMtitle 	 a.Add  a.Remove  a.Clear  
a.Settings 
 a.Info  a.SaveGroup  a.LoadGroup 	 a.Start 
 a.Cancel 
 a.Save  a.StartWindowtitle  a.InfoWindowtitle  a.MergingMidis  a.Setppq  a.ImpBpm  a.ImpMrg  a.RemBpm  a.RemPC  a.RemPB  a.RemEpt  a.TrsPpq 	 a.ch1  a.Offst  a.MinvolFront  a.OKkey  
a.Filename  
a.Filesize  a.Trkcnt  a.OriginalPpq  a.Notecount   	a.Midilen ! a.Getmoreinfo " 
a.Finished # a.Failed $ 	a.Stopped % a.Parsingtrack & a.UnableGroup ' a.Clickgetinfo ( a.ProcessedTracks ) a.clearwarn 	* .Lang + .CJCAMMInfo , 
.CJCORInfo - .CJCMCGInfo . .Version / o.CJCORtitle 0 o.AudioRender 1 o.NotesRemain 2 o.OverlapRate 3 o.Prereading 4 o.Parsingtrack 5 o.Start 6 o.SuccessfullyOutput 7 m.CJCMCGtitle 8 m.SelectFile 9 m.Width : m.Height 	; m.Fps < m.Preset = 	m.Preview > m.PatSel ? m.FonSel @ m.FonSz A m.Color B m.Align C 	m.AlignUL D 	m.AlignUR E 	m.AlignUM F 	m.AlignDL G 	m.AlignDR H 	m.AlignDM I m.OutputToCjcmcg J m.PatSv K 
m.ColorChg L m.OKkey M 
m.ReadHelp N m.Remove 
O m.Savv P m.Parsingtrack Q m.Start R m.Cancel S 
m.Finished T m.Failed U 	m.Stopped V m.ReadFinished W m.FrameRender X m.DelayStart Y m.DetectedOld Z m.ConvertFin [ m.UpdateOld \ m.cjcmcg_help�� 6   D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     6W   ,s&clr-namespace:System;assembly=mscorlib  6�   %�  &	        &	 #     &	 S     &	 q     &	 �     &	 �     &	 �     &	 �     &	     &		 .    &	
 L    &	 l    &	 �    &	 �    &	 �    &	 	    &	 *    &	 q    &	 �    &	 �    &	 H    &	 �    &	 �    &	 �    &	 &    &	 Q    &	 �    &	 �    &	 �    &	     &	 .    &	 Q    &	  w    &	! �    &	" �    &	# �    &	$     &	% 2    &	& u    &	' �    &	(     &	) b    &	* �    &	+ �    &	, k    &	- �    &	. �	    &	/ �	    &	0 �	    &	1 6
    &	2 \
    &	3 z
    &	4 �
    &	5 �
    &	6     &	7 B    &	8 t    &	9 �    &	: �    &	; �    &	< �    &	=     &	> 1    &	? M    &	@ i    &	A �    &	B �    &	C �    &	D �    &	E     &	F 1    &	G S    &	H v    &	I �    &	J �    &	K �    &	L     &	M )    &	N Z    &	O |    &	P �    &	Q �    &	R �    &	S     &	T <    &	U Z    &	V {    &	W �    &	X �    &	Y     &	Z t    &	[ �    &	\ �    ��5      CJC Toolbox��6/   ��5      CJC Advanced MIDI Merger��6?   ��5      
Tambah��6%   ��5      	Hapus��6'   ��5      	Bersihkan��6*   ��5	      Setelan��6+   ��5
      Info��6$   ��5      Simpan Grup��60   ��5      	Buka Grup��6.   ��5      
Mulai!��6'   ��5      Batalkan��6*   ��5      Simpan!��6'   ��5      Mulai menggabungkan��6?   ��5      Informasi MIDI��69   ��5      Menggabungkan MIDI...��6=   ��5      	Setel PPQ��6+   ��5      3/Tempatkan gabungan dari BPM menuju trek pertama��6Q   ��5      0,Tempatkan semua gabungan menuju trek pertama��6N   ��5      Singkirkan semua BPM events��6=   ��5      LHSingkirkan semua "program change" event (Setel semua instrumen ke piano)��6s   ��5      $ Singkirkan semua lengkungan nada��6A   ��5      Singkirkan trek yang kosong��6=   ��5      ,(Konversi PPQ yang asli menjadi PPQ utama��6J   ��5      Semua saluran diubah ke CH1��6:   ��5      Setel offset (tick)��64   ��5      84Singkirkan note dengan volume tidak lebih besar dari��6[   ��5      Oke��6$   ��5      Nama file: ��6/   ��5       Ukuran file (bit): ��67   ��5!      Jumlah trek: ��6/   ��5"      PPQ Asli: ��61   ��5#      Jumlah note: ��62   ��5$      Durasi MIDI (tick): ��67   ��5%      Informasi lebih lanjut��6=   ��5&      	Berhasil.��6-   ��5'      
Gagal.��6(   ��5(      	Terhenti.��6,   ��5)      /+Mengurai trek {trackcount}, {tracksize} bit��6S   ��5*      D@Tidak dapat memperoleh informasi lebih banyak dari file grup ini��6g   ��5+      =9(Klik "Informasi lebih lanjut" dibawah untuk mendapatkan)��6k   ��5,      0,{trks} trek diproses, {wrtt} trek ditulis...��6W   ��5-      .*Apakah kamu ingin menghapus daftar isinya?��6O   ��5/      Bahasa:��6&   ��50      ��CJC Advanced MIDI Merger
Sebuah software yang digunakan untuk menggabungkan beberapa MIDI dan menampilkan informasi tentang MIDI tersebut.��51   t   ��52      c_CJC Overlap Remover
Sebuah software yang digunakan untuk menyingkirkan note berlebih pada MIDI.��53   N   ��54      ��CJC MIDI Counter Generator
Karya representatif dari CJC Apps. Sebuah software yang digunakan untuk membuat sebuah counter/penghitung dari MIDI.��55   w   ��56      
Versi ��6=   ��58      CJC Overlap Remover��69   ��59      FBGunakan audio render (Kualitas audio lebih baik, namun lebih lama)��6i   ��5:      Note tersisa: ��6J   ��5;      
Rate: ��6B   ��5<       Prereading trek {trackcount}��6B   ��5=      /+Mengurai trek {trackcount}, {tracksize} bit��6S   ��5>      
Mulai!��6'   ��5?      Berhasil menyimpan file di ��6^   ��5A      CJC MIDI Counter Generator��6A   ��5B      
Pilih File��60   ��5C      	Lebar��6&   ��5D      Panjang��6)   ��5E      FPS��6"   ��5F      
Preset��6(   ��5G      Pratinjau Teks��61   ��5H      Pola��6&   ��5I      Font��6&   ��5J      Ukuran Teks��6,   ��5K      	Warna��6&   ��5L      
Sejajarkan��6+   ��5M      	Kiri Atas��6,   ��5N      
Kanan Atas��6-   ��5O      Tengah Atas��6.   ��5P      
Kiri Bawah��6-   ��5Q      Kanan Bawah��6.   ��5R      Tengah Bawah��6/   ��5S      Hanya file praproses saja��6C   ��5T      	Ubah Pola��6*   ��5U      
Ubah Warna��6.   ��5V      Oke��6$   ��5W      Instruksi untuk digunakan��6=   ��5X      
Singkirkan��6,   ��5Y      
Simpan��6&   ��5Z      /+Mengurai trek {trackcount}, {tracksize} bit��6S   ��5[      
Mulai!��6'   ��5\      Batalkan��6*   ��5]      	Berhasil.��6-   ��5^      
Gagal.��6(   ��5_      	Terhenti.��6,   ��5`      $ Berhasil dibaca. {notecnt} note.��6H   ��5a      '#Terrender {frames} frame, {fps} FPS��6J   ��5b      Waktu tunda (detik):��6:   ��5c      FBTerdeteksi bahwa ini adalah pola lama, konversi menjadi pola baru?��6i   ��5d      Konversi berhasil. Simpan?��6@   ��5e      Perbarui pola?��63   ��5f      ��Software ini dibuat oleh CJC Apps. Pastikan ada ffmpeg.exe di folder yang sama dengan program atau di C:\Windows\System32. Jika kamu tidak punya, segera untuk mengunduh di http://ffmpeg.org . Disarankan juga untuk mengunduh xz.exe (dari https://tukaani.org/xz) untuk menghindari masalah ketika mendekrompresi MIDI.

Pastikan juga kamu menginstall Python 3, menambahkan itu ke PATH dan menginstall Natsulang dengan pip, untuk menjalankan Natsulang secara normal.

Program ini menggunakan Natsulang untuk membuat counter. Ini adalah bahasa pengolah teks oleh CJC.

Kamu bisa membuat program Natsulang dari variabel berikut:
  frm: Frame video saat ini (dimulai dari 0)
  nc: Note Count:
  an: Semua note
  BPM: Ketukan per menit
  tm: Waktu (detik, direkomendasikan untuk menampilkan dengan dua desimal, lihat instruksi dibawah)
  nps: Note per detik
  pol: Polifoni
  tic: Tick
  ati: Semua tick
  bts: Ketukan
  ati: Semua ketukan
  ppq: Resolusi (PPQ)
  lrc: Lirik
  lrc_frm: Frame sejak lirik ini muncul (dimulai dari 0)

Kamu dapat menggunakan "{variable}" untuk menampilkan nilai dari variabel. Kamu dapat memasukan ekspresi untuk membuat beberapa perhitungan yang kompleks. Jika kamu ingin menghasilkan sebuah angka dengan koma per tiga digit, kamu dapat menggunakan "{format({number},',')}". Jika kamu ingin menghasilkan waktu dengan dua desimal, kamu dapat menggunakan "{format(tm,'.2f')}".

Jika kamu menggunakan counter ini di videomu, jangan lupa untuk kredit kami seperti ini:
MIDI Counter dirender oleh CJCMCG dari CJC Apps.
https://github.com/Ace-tyl/CJC-Toolbox-Reborn��5�   0   5�      
# Search Aggregate Notes

## Muc tieu

Chot yeu cau va cac quyet dinh cho chuc nang tim kiem tong hop gom `Bac si` va `Bai viet`, de cac lan sau co the tiep tuc thao luan/implement ma khong mat context.

## Pham vi tim kiem

### Bac si

- Tim theo:
  - ten bac si
  - ten phong kham
  - dia chi phong kham

- Filter:
  - chuyen khoa: khong chon / chon 1 / chon nhieu
  - khu vuc 2 cap:
    - tinh/thanh: khong chon hoac chon 1
    - quan/huyen: chi duoc chon sau khi da chon tinh/thanh; khong chon / chon 1 / chon nhieu
  - gioi tinh: khong chon hoac chon 1

- Sort:
  - gia kham thap den cao
  - gia kham cao den thap
  - nam kinh nghiem cao den thap
  - rating cao den thap

### Bai viet

- Tim theo:
  - tieu de bai viet

- Filter:
  - chuyen khoa: khong chon / chon 1 / chon nhieu

- Sort:
  - moi nhat
  - xem nhieu nhat
  - xem it nhat

## Quy tac du lieu va UX da chot

- Chuyen khoa la du lieu dong:
  - He thong co chuyen khoa nao trong DB thi frontend hien chuyen khoa do.
  - Khong hard-code danh sach chuyen khoa trong UI.

- Khu vuc la filter phu thuoc:
  - Phai chon `Tinh/Thanh` truoc thi `Quan/Huyen` moi duoc enabled.
  - Khi doi `Tinh/Thanh`, danh sach `Quan/Huyen` phai reload theo tinh/thanh da chon.

- Khu vuc ket qua:
  - Co tab `Bac si` va `Bai viet`
  - Moi tab hien so luong ket qua
  - Co loading state, empty state, result state

- Ngay ben duoi `search bar` co khu vuc goi y cum tu lien quan theo noi dung nguoi dung dang go.

## Quy tac sort kinh nghiem bac si

- Neu co loc chuyen khoa:
  - sort theo `Experience_Years` cua bac si trong chuyen khoa dang loc.

- Neu khong loc chuyen khoa:
  - sort theo `ExperienceSummary`.

## Danh gia backend hien tai

### Da co

- Search tong hop tra ve 2 nhom ket qua: doctors + articles
- Tim bac si theo:
  - ten bac si
  - ten phong kham
  - dia chi phong kham
- Tim bai viet theo tieu de
- Filter chuyen khoa cho bac si va bai viet theo kieu chon nhieu
- Filter gioi tinh cho bac si
- Sort bai viet:
  - moi nhat
  - xem nhieu nhat
  - xem it nhat

### Chua du / can sua

- Chua co filter khu vuc 2 cap theo `Province` va `LocationName`
- Chua co sort bac si theo:
  - gia kham thap den cao
  - gia kham cao den thap
- Sort rating bac si hien co nhung chua dang tin vi can load/tinh reviews trong luong search
- Can thong nhat sort kinh nghiem:
  - co loc chuyen khoa -> `Experience_Years`
  - khong loc chuyen khoa -> `ExperienceSummary`
- Chua co suggestion keywords duoi search bar
- Can dam bao search bac si chi lay bac si da duyet (`IsApproved`)
- Nen chuan hoa response de frontend de dung:
  - doctors
  - articles
  - doctorCount
  - articleCount
  - suggestions

## Noi dung gui frontend

Chuc nang tim kiem tong hop gom 2 nhom ket qua: `Bac si` va `Bai viet`.

O tim kiem chung:

- Nguoi dung nhap tu khoa tai `search bar`.
- Ngay ben duoi `search bar` co khu vuc hien thi `goi y cum tu lien quan` theo noi dung nguoi dung dang go.

Quy tac tim kiem:

- Bac si duoc tim theo: `ten bac si`, `ten phong kham`, `dia chi phong kham`.
- Bai viet duoc tim theo: `tieu de bai viet`.

Filter cho Bac si:

- `Chuyen khoa`: danh sach chuyen khoa la du lieu dong tu he thong; co chuyen khoa nao trong DB thi hien chuyen khoa do. Nguoi dung co the `khong chon`, `chon 1`, hoac `chon nhieu`.
- `Khu vuc` gom 2 cap:
  - `Tinh/Thanh`: cho phep `khong chon` hoac `chon 1`.
  - `Quan/Huyen`: chi duoc chon sau khi da chon `Tinh/Thanh`; cho phep `khong chon`, `chon 1`, hoac `chon nhieu`.
- `Gioi tinh`: cho phep `khong chon` hoac `chon 1`.
- `Sap xep`: gom
  - `Gia kham thap den cao`
  - `Gia kham cao den thap`
  - `Nam kinh nghiem cao den thap`
  - `Rating cao den thap`

Quy tac sap xep kinh nghiem cho Bac si:

- Neu nguoi dung co loc `chuyen khoa`, he thong sap xep theo `so nam kinh nghiem cua bac si trong chuyen khoa dang loc`.
- Neu nguoi dung khong loc `chuyen khoa`, he thong sap xep theo `tong so nam kinh nghiem` cua bac si.

Filter cho Bai viet:

- `Chuyen khoa`: danh sach chuyen khoa la du lieu dong tu he thong; co chuyen khoa nao trong DB thi hien chuyen khoa do. Nguoi dung co the `khong chon`, `chon 1`, hoac `chon nhieu`.
- `Sap xep`: gom
  - `Moi nhat`
  - `Xem nhieu nhat`
  - `Xem it nhat`

Khu vuc hien thi ket qua:

- Co `tab` chuyen giua `Bac si` va `Bai viet`.
- Moi tab hien thi `so luong ket qua`.
- Moi loai ket qua co card hien thi rieng.
- Can co trang thai `dang tai`, `khong co ket qua`, va `co ket qua`.

## Ghi chu cho lan sau

Neu tiep tuc thuc hien, uu tien tiep theo nen la:

1. Chot API contract cho integrated search
2. Bo sung backend gaps
3. Moi map UI voi frontend spec

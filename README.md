# Báo cáo sau khi làm bài test

## Đã làm được:

Trong 3 ngày (+ 1 ngày mình xin thêm do bận việc ở những ngày trước), mình đã làm được 1 demo FPS đơn giản với 1 player có các thao tác cơ bản cũng như các enemy để player tham gia chiến đấu. Chi tiết hơn:

- Player có thể di chuyển theo các phím cơ bản (WASD) và có thể thao tác với vũ khí (súng) (Left Click = Shoot, Right Click = Aim), player cũng đã có HitPoint, mặc dù chưa dùng đến

- Đã phân loại các object vũ khí sang 3 loại chính (primary, secondary, throwable), nhưng hiện chỉ có script cho vũ khí tầm xa (GunController.cs); trong script này vũ khí có FX khi bắn, có cơ chế đạn cơ bản (Ammo + Magazine) và RayCast hit để tương tác với các object khác

- Enemy có thể di chuyển cơ bản, có HitPoint và sẽ Die() khi HitPoint về 0

## Những phần đã plan nhưng chưa làm được:

- Cho player cơ chế chọn nhân vật để spawn, và có thể chọn/random vị trí spawn

- Add thêm vũ khí secondary và throwable, cho phép lựa chọn các loại vũ khí, add mechanic cho throwable và melee weapon

- Thêm animation cho phần thay đạn, custom gunsplash cho từng loại súng, có animation riêng cho các vũ khí đặc biệt (vd: cung)

- Thêm FX ở các điểm tiếp xúc giữa đường đạn của vũ khí và các object khác (đã add FX_BloodSplatter cho enemy nhưng chưa hoạt động)

- Thêm tương tác gây damage cho player của enemy, add animation cho các đòn đánh, animation cho lúc die

- Đa dạng hóa enemy với các thông số khác nhau về HitPoint, Damage, Speed, PatrolPath, etc.

- Thêm UI Menu và các menu tương ứng cho từng flow của game (Start, Play, End, etc.)

- Thêm các tương tác với môi trường xung quanh (lửa cháy gây damage, bình xăng gây nổ, máy bay tiếp tục bay, etc.)

## Ý kiến cá nhân:

Mình thừa nhận là trước khi làm bài test này mình có rất ít kinh nghiệm về mảng FPS, và thời gian cho bài test cũng hạn hẹp (+ bản thân cũng bận) nên mình đã không hoàn thành bài test một cách tốt nhất. Dù sao thì cũng cảm ơn mọi người đã cho mình cơ hội trải nghiệm và học hỏi.

Võ Phú Thành
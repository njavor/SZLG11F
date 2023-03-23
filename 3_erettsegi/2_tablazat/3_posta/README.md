# [Posta feladatsor](/3_erettsegi/2_tablazat/3_posta/feladatok.pdf)

#### 2. Ügyfél által választott szolgáltatás
```
=FKERES($A2;$G$7:$H$9;2;IGAZ)
```

#### 3. Hivatalban töltött idő
```
=D2-B2
```

#### 4. Egyes szolgáltatásokat választók száma
```
=DARABHATÖBB($C:$C;H2)
```

#### 5. Átlagos hivatalban töltött idő szolgáltatásonként
```
=ÁTLAGHA($C:$C;H2;$E:$E)
```

#### 6. Leghosszabb hivatalban töltött idő
```
=MAX(E:E)
```

#### 7. Legtöbb időt hivatalban töltő ügyfél sorszáma, szolgáltatásának jellege
```
=INDEX(A:A;HOL.VAN(H11;E:E;0))
=FKERES(H12;A:C;3)
```

![](/_assets/3_2_3.png)
# [Fogyasztás feladatsor](/3_erettsegi/2_tablazat/1_fogyasztas/feladatok.pdf)

#### 2. Benzin literenkénti ára (függvénnyel két tizedesre kerekítve)
```
=KEREKÍTÉS($D2/$C2; 2)
```

#### 3. Autó benzinfogyasztása 100 kilométerenként
```
=$C2/$B2*100
```

#### 4., 5. Táblázat időszakában megtett távolság *(4.)* és tankolt benzin *(5.)*
```
=SZUM(B:B), =SZUM(C:C)
```

#### 6. Átlagos benzinfogyasztás 100 kilométerenként
```
=K3/K2*100
```

#### 7. 'X' cégnél való tankolások száma
```
=DARABHATÖBB(R:R;BAL(J5;1))
```
segédtábla
```
=HA($E2="NA"; ""; BAL($E2; 1))
```

#### 8. Adott évben tankolt benzin
```
=SZUMHA(S:S;I9;C:C)
```
segédtábla
```
=SZUMHA(S:S;I9;C:C)
```
![](/_assets/3_2_1.png)

# [Segítők feladatsor](/3_erettsegi/2_tablazat/2_segitok/feladatok.pdf)

#### 4. Szomszédos cella dátumának napja
```
=HÉT.NAPJA(A2)
```

#### 5. Látogatások száma
```
=DARAB2(C2:C32)
```

#### 6. Első látogatás időpontja
```
=MIN(C2:E2)
```

#### 7. Utolsó látogatás időpontja
```
=HA(DARAB2(C2:E2)=1;"";MAX(C2:E2))
```

#### 8. Adott nap első látogatója
```
=INDEX($C$1:$E$1;HOL.VAN(F2;C2:E2;))
```

#### 9. Első érkezések száma
```
=DARABTELI($H$2:$H$32;C1)
```

![](/_assets/3_2_2.png)
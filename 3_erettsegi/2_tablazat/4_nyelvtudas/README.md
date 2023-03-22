# [Nyelvtudás feladatsor](/3_erettsegi/2_tablazat/4_nyelvtudas/feladatok.pdf)

#### 3.  Adott ország egy idegen nyelvet sem beszélő lakossága
```
=1-B2
```

#### 4. Adott országban legalább egy idegen nyelvet beszélők száma (ezer fő)
```
=F2*B2/1
```

#### 5. Uniós országok száma, amik lakossága 60%-nál nagyobb, illetve 40%-nál kisebb arányban beszél legalább x idegen nyelvet?
```
=DARABHATÖBB(B2:B28;">0,6")/DARAB2(B2:B28)
=DARABHATÖBB(B2:B28;"<0,4")/DARAB2(B2:B28)
```

#### 6. Unió lakosainak száma + legalább 1 idegen nyelvet beszélők száma
```
=SZUM(F2:F28)
```

#### 7. Legalább 1 idegen nyelvet beszélők rangsorának első, második, utolsó előtti és utolsó országa
```
=MAX(B2:B28)
=NAGY(B2:B28;2)
=KICSI(B2:B28;2)
=MIN(B2:B28)

=INDEX($A$2:$A$28;HOL.VAN(L2;$B$2:$B$28;0))
```

#### 8. Uniós átlag
```
=G31/F31
```

#### 9. Adott ország helyzete az uniós átlaghoz képest
```
=HA(B2<$L$7;"-";"+")
```

![](/_assets/3_2_4.png)
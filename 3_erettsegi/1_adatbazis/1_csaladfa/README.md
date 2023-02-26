# [Családfa feladatsor](https://github.com/MolnAtt/SQL/tree/main/feladatsorok/Csaladfa)

## Adatok áttekintése (1,2)
#### Szülő-gyerek reláción alapuló tábla, ahol a szülők és gyerekek a vezeték és keresztnevükkel szerepelnek
```sql
SELECT U.veznev&" "&U.kernev&" -> "&U_1.veznev&" "&U_1.kernev
FROM U AS U_1 INNER JOIN (U INNER JOIN G ON U.id = G.szulo) ON U_1.id = G.gyerek;
```



## Elemi összesítések
#### 1. Vezetéknevek az adatbázisban
```sql
SELECT DISTINCT veznev FROM U;
```

#### 2. Különböző vezetéknevek száma
```sql
SELECT COUNT(*)
FROM ( SELECT DISTINCT veznev FROM U);
```

#### 3. Legelső és legutolsó vezetéknév
```sql
SELECT  TOP 1 veznev FROM U
ORDER BY id DESC
UNION 
SELECT TOP 1 veznev FROM U;
```

#### 4. Férfiak és nők száma
```sql
SELECT COUNT(*) FROM U
WHERE nem = "Férfi"
UNION
SELECT COUNT(*) FROM U
WHERE nem = "Nő";
```



## Elemi csoportosítások
#### 1. Legtöbbek által viselt vezetéknév
```sql
SELECT TOP 1 veznev, COUNT(*) FROM U
GROUP BY veznev
ORDER BY COUNT(*) DESC;
```

#### 2. X-gyerekkel rendelkező szülők száma
```sql
SELECT szulo, COUNT(*) as gyerekszam FROM G
GROUP BY szulo;
```

#### 3. Legtöbb gyerek száma
```sql
SELECT TOP 1 COUNT(*) AS gyerekszam FROM G
GROUP BY szulo
ORDER BY COUNT(*) DESC, szulo;
```

#### 4. Kétgyerekes szülők száma
```sql
SELECT COUNT(*) AS 2gyerekes
FROM (SELECT szulo FROM G
GROUP BY szulo
HAVING COUNT(*) = 2);
```

#### 5. Egygyerekes, kétgyerekes, stb. szülők száma
```sql
SELECT gyerekszam, COUNT(*) as db
FROM (SELECT szulo, COUNT(gyerek) AS gyerekszam FROM G 
GROUP BY szulo)
GROUP BY gyerekszam;
```

#### 6. Csak egy ember által viselt vezetéknevek száma
```sql
SELECT COUNT(*)
FROM (SELECT veznev, COUNT(*) AS db FROM U
GROUP BY veznev)
WHERE db = 1;
```



## Projekciók
#### 1. Szülők
```sql
SELECT szulo FROM G
GROUP BY szulo;
```

#### 2. Szülők száma
```sql
SELECT COUNT(*)
FROM (SELECT szulo FROM G
GROUP BY szulo);
```

#### 3. Szülők (névvel), vezetéknév *(majd keresztnév)* szerint ábécésorrendben
```sql
SELECT veznev, kernev
FROM U INNER JOIN G ON U.id = G.szulo
GROUP BY id, veznev, kernev
ORDER BY veznev, kernev;
```

#### 4. Legelső szülő a névsorában
```sql
SELECT TOP 1 veznev, kernev
FROM U INNER JOIN G ON U.id = G.szulo
GROUP BY id, veznev, kernev
ORDER BY veznev, kernev;
```

#### 5. Gyermekek
```sql
SELECT gyerek FROM G
GROUP BY gyerek;
```

#### 6. Gyermekek száma
```sql
SELECT COUNT(*)
FROM (SELECT gyerek FROM G
GROUP BY gyerek);
```

#### 7. Gyermekek (névvel), vezetéknév *(majd keresztnév)* szerint ábécésorrendben
```sql
SELECT veznev, kernev
FROM U INNER JOIN G ON U.id = G.gyerek
GROUP BY id, veznev, kernev
ORDER BY veznev, kernev;
```

#### 8. Legutolsó gyermek a névsorában
```sql
SELECT TOP 1 veznev, kernev
FROM U INNER JOIN G ON U.id = G.gyerek
GROUP BY id, veznev, kernev
ORDER BY veznev DESC, kernev DESC;
```



## Definíciók
### Lánya
#### 1. "x Lánya y" reláció
```sql
SELECT G.szulo&" -> "&G.gyerek
FROM U INNER JOIN G ON U.id = G.gyerek
WHERE U.nem = "Nő";
```

#### 2. "x Lánya y" névvel
```sql
SELECT U.veznev&" "&U.kernev& "  ->  " &U_1.veznev&" "&U_1.kernev
FROM U AS U_1 INNER JOIN (U INNER JOIN G ON U.id = G.szulo) ON U_1.id = G.gyerek
WHERE U_1.nem = "Nő";
```


### Apja
#### 1. "x Apja y-nak" reláció
```sql
SELECT G.szulo&" -> "&G.gyerek
FROM U INNER JOIN G ON U.id = G.szulo
WHERE U.nem = "Férfi";
```

#### 2. "x Apja y-nak" névvel
```sql
SELECT U.veznev&" "&U.kernev& "  ->  " &U_1.veznev&" "&U_1.kernev
FROM U AS U_1 INNER JOIN (U INNER JOIN G ON U.id = G.szulo) ON U_1.id = G.gyerek
WHERE U.nem = "Férfi";
```


### Unoka
#### 1. "x Unokája y-nak" reláció
```sql
SELECT G.szulo&" -> "&G_1.gyerek
FROM G INNER JOIN G AS G_1 ON G.gyerek = G_1.szulo;
```

#### 2. "x Unokája y-nak" névvel
```sql
SELECT U.veznev&" "&U.kernev& "  ->  " &U_1.veznev&" "&U_1.kernev
FROM U AS U_1 INNER JOIN (U INNER JOIN (G INNER JOIN G AS G_1 ON G.gyerek = G_1.szulo) ON U.id = G.szulo) ON U_1.id = G_1.gyerek;
```


### Pár
#### 1. "x Párja y-nak" reláció *(van közös gyerekük)*
```sql
SELECT "("&G.szulo&" , "&G_1.szulo&")"
FROM G, G AS G_1
WHERE G.gyerek = G_1.gyerek AND G.szulo < G_1.szulo
GROUP BY G.szulo, G_1.szulo;
```

#### 2. "x Párja y-nak" névvel
```sql
SELECT "("&U.veznev&" "&U.kernev&" , "&U_1.veznev&" "&U_1.kernev&")"
FROM U AS U_1 INNER JOIN G AS G_1 ON U_1.id = G_1.szulo, U INNER JOIN G ON U.id = G.szulo
WHERE G.gyerek = G_1.gyerek AND G.szulo < G_1.szulo
GROUP BY G.szulo, G_1.szulo, U.veznev, U.kernev, U_1.veznev, U_1.kernev;
```


### Testvér
#### 1. "x Testvére y-nak" reláció *(van közös szülőjük)*
```sql
SELECT "("&G.gyerek&" , "&G_1.gyerek&")"
FROM G, G AS G_1
WHERE G.szulo = G_1.szulo AND G.gyerek < G_1.gyerek
GROUP BY G.gyerek, G_1.gyerek;
```

#### 2. "x Testvére y-nak" névvel
```sql
SELECT "("&U.veznev&" "&U.kernev&" , "&U_1.veznev&" "&U_1.kernev&")"
FROM U AS U_1 INNER JOIN G AS G_1 ON U_1.id = G_1.gyerek, U INNER JOIN G ON U.id = G.gyerek
WHERE G.szulo = G_1.szulo AND G.gyerek < G_1.gyerek
GROUP BY G.gyerek, G_1.gyerek, U.veznev, U.kernev, U_1.veznev, U_1.kernev;
```


### Húg
#### 1. "x Húga y-nak" *(fiatalabb lánytestvér; nagyobb id, mint testvérének)*
```sql
SELECT G.gyerek&" -> "&G_1.gyerek
FROM G AS G_1, U INNER JOIN G ON U.id = G.gyerek
WHERE G.szulo = G_1.szulo AND G.gyerek > G_1.gyerek AND U.nem = "Nő"
GROUP BY G.gyerek, G_1.gyerek;
```

#### 2. "x Húga y-nak" névvel
```sql
SELECT U.veznev&" "&U.kernev &" -> "&U_1.veznev&" "&U_1.kernev
FROM U INNER JOIN G ON U.id = G.gyerek, U AS U_1 INNER JOIN G AS G_1 ON U_1.id = G_1.gyerek
WHERE G.szulo = G_1.szulo AND G.gyerek > G_1.gyerek AND U.nem = "Nő"
GROUP BY G.gyerek, G_1.gyerek, U.veznev, U.kernev, U_1.veznev, U_1.kernev;
```


### Fiús anyuka
#### 1. "x Fiús_anyuka" reláció *(anya minden gyermeke fiú)*
```sql
SELECT szulo
FROM U INNER JOIN G ON U.id = G.szulo
WHERE U.nem = "Nő" AND szulo NOT IN (SELECT szulo
FROM U AS U_1 INNER JOIN (U INNER JOIN G ON U.id = G.szulo) ON U_1.id = G.gyerek
WHERE U_1.nem = "Nő")
GROUP BY szulo;
```

#### 2. "x Fiús_anyuka" névvel
```sql
SELECT veznev&" "&kernev
FROM U INNER JOIN G ON U.id = G.szulo
WHERE U.nem = "Nő" AND szulo NOT IN (SELECT szulo
FROM U AS U_1 INNER JOIN (U INNER JOIN G ON U.id = G.szulo) ON U_1.id = G.gyerek
WHERE U_1.nem = "Nő")
GROUP BY szulo, veznev, kernev;
```


### Unokatestvér
#### 1. "x Unokatestvére y-nak" reláció
```sql
SELECT G_2.gyerek&" -> "&G_3.gyerek
FROM G INNER JOIN G AS G_2 ON G.gyerek = G_2.szulo, G AS G_1 INNER JOIN G AS G_3 ON G_1.gyerek = G_3.szulo
WHERE G.szulo = G_1.szulo AND G_2.szulo <> G_3.szulo AND G_2.gyerek < G_3.gyerek
GROUP BY G_2.gyerek, G_3.gyerek;
```

#### 2. "x Unokatestvére y-nak" névvel
```sql
SELECT U.veznev&" "&U.kernev&"  ->  "&U_1.veznev&" "&U_1.kernev
FROM U INNER JOIN (G INNER JOIN G AS G_2 ON G.gyerek = G_2.szulo) ON U.id = G_2.gyerek, U AS U_1 INNER JOIN (G AS G_1 INNER JOIN G AS G_3 ON G_1.gyerek = G_3.szulo) ON U_1.id = G_3.gyerek
WHERE G.szulo = G_1.szulo AND G_2.szulo <> G_3.szulo AND G_2.gyerek < G_3.gyerek
GROUP BY G_2.gyerek, G_3.gyerek, U.veznev, U.kernev, U_1.veznev, U_1.kernev;
```


### Testvérházasság
#### 1. "x Testvérpárja y-nak" reláció *(Pár ∧ Testvér)*
```sql
SELECT DISTINCT G.szulo, G_1.szulo
FROM ((G INNER JOIN G AS G_1 ON G.gyerek = G_1.gyerek) INNER JOIN G AS G_3 ON G_1.szulo = G_3.gyerek) INNER JOIN G AS G_2 ON G_2.szulo = G_3.szulo AND G.szulo = G_2.gyerek
WHERE G.szulo<G_1.szulo AND G_3.szulo<G_2.szulo;
```



## Negáció
#### 1. Családfa gyökerei
```sql
SELECT szulo FROM G
WHERE szulo NOT IN (SELECT gyerek
FROM G)
GROUP BY szulo;
```

#### 2. Gyermeknélküliek
```sql
SELECT gyerek FROM G
WHERE gyerek NOT IN (SELECT szulo
FROM G)
GROUP BY gyerek;
```

#### 3. Gyerekesek pár nélkül
```sql
SELECT szulo FROM G
WHERE szulo NOT IN (SELECT G.szulo
FROM G, G AS G_1
WHERE G.gyerek = G_1.gyerek AND G.szulo <> G_1.szulo
GROUP BY G.szulo, G_1.szulo);
```



## Komplex
#### 1. Egykék
```sql
SELECT gyerek FROM G
WHERE szulo IN (SELECT szulo
FROM (SELECT szulo, COUNT(*) AS gyerekszam
FROM G GROUP BY szulo)
WHERE gyerekszam = 1)
GROUP BY gyerek;
```

#### 2. Nagyszülők a legtöbb unokával (unokák számával)
```sql
SELECT TOP 1 G.szulo, COUNT(*)
FROM G INNER JOIN G AS G_1 ON G.gyerek = G_1.szulo
GROUP BY G.szulo
ORDER BY COUNT(*) DESC;
```

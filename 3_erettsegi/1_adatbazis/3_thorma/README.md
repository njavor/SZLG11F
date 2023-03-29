# [Thorma János Múzeum érettségi feladatsor](/3_erettsegi/1_adatbazis/3_thorma/feladatok.pdf)

#### 2. 
```
SELECT nev
FROM festok
WHERE szuletett <= 1914 AND 1914 <= meghalt
ORDER BY nev;
```

#### 3.
```
SELECT DISTINCT(anyag)
FROM kepek
WHERE technika = "olaj";
```

```
SELECT cim, szeles, magas, nev
FROM kepek INNER JOIN festok ON kepek.fazon = festok.azon
WHERE cim LIKE "*domb*";
```

```
SELECT TOP 1 cim, nev
FROM kepek INNER JOIN festok ON kepek.fazon = festok.azon
ORDER BY magas DESC
```


```
SELECT keszult, COUNT(*)
FROM kepek
GROUP BY keszult
ORDER BY COUNT(*);
```
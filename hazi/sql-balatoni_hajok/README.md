# [Balatoni hajók érettségi feladatsor](https://github.com/MolnAtt/SQL/blob/main/feladatsorok/erettsegi/balatoni-hajok/balatoni%20haj%C3%B3k%20F/balatoni%20haj%C3%B3k.pdf)

### 2. Üzemelelő személyhajók ábécé sorrendben
```sql
SELECT nev FROM hajo
WHERE uzemel = True AND tipus = "személyhajó"
ORDER BY nev;
```

### 3. "Balaton" szórészletet tartalmazó hajók
```sql
SELECT tulajdonos.nev, hajo.nev
FROM hajo INNER JOIN tulajdonos ON hajo.tulaz = tulajdonos.az
WHERE hajo.nev LIKE "*Balaton*";
```

### 4. Üzemelő hajók típusonként
```sql
SELECT tipus, COUNT(*) FROM hajo
GROUP BY tipus
ORDER BY COUNT(*) DESC;

```

### 5. Névváltoztatás nélküli hajók
```sql
SELECT COUNT(*) FROM hajo
WHERE az NOT IN (SELECT hajoaz FROM tort);
```

### 6. Legtöbb névváltoztatáson átesett hajók
```sql
SELECT TOP 1 hajo.nev, tulajdonos.nev
FROM tulajdonos INNER JOIN (hajo INNER JOIN tort ON hajo.az = tort.hajoaz) ON tulajdonos.az = hajo.tulaz
GROUP BY hajoaz, hajo.nev, tulajdonos.nev
ORDER BY COUNT(*) DESC;
```

### 7. "Akali" tulajdonosának összes hajója
```sql
SELECT nev,  tipus FROM hajo
WHERE tulaz IN (SELECT tulaz FROM hajo
WHERE nev = "Akali");
```

### 8. Személyhajóval és vitorlással is rendelkező tulajdonosok
```sql
SELECT DISTINCT tulajdonos.nev, varos
FROM hajo INNER JOIN tulajdonos ON hajo.tulaz = tulajdonos.az
WHERE tipus = "személyhajó"
AND tulaz IN (SELECT tulaz FROM hajo
WHERE tipus = "vitorlás");
```

### 9.1. Üzemelő személyhajók tulajdonosai
```sql
SELECT tulaz FROM hajo
WHERE tipus = "személyhajó" AND uzemel = True
GROUP BY tulaz;
```
### 9.2. Négy, vagy több hajóval rendelkező tulajdonosok
```sql
SELECT tulaz FROM hajo
GROUP BY tulaz
HAVING 4 <= COUNT(*);
```

### 10. Jelentés a hajókról tulajdonosuk szerint
```sql
SELECT tulajdonos.nev&" "&varos, tipus, hajo.nev
FROM hajo INNER JOIN tulajdonos ON hajo.tulaz = tulajdonos.az
ORDER BY tulajdonos.nev, tipus;
```
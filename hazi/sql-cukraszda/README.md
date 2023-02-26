# [Cukrászda érettségi feladatsor](https://github.com/MolnAtt/SQL/blob/main/feladatsorok/erettsegi/cukraszda-k/cukr%C3%A1szda%20F/Cukr%C3%A1szda.pdf)

### 2. Díjazott torták ábécé sorrendben
```sql
SELECT nev FROM suti
WHERE tipus = "torta" AND dijazott = True
ORDER BY nev;
```

### 3. Db-ra vásárolható sütemények átlagos ára
```sql
SELECT ROUND(SUM(ertek)/COUNT(*),2)
FROM suti INNER JOIN ar ON suti.id = ar.sutiid
GROUP BY egyseg
HAVING egyseg="db";
```

### 4. Laktózmentes piték és tortaszeletek
```sql
SELECT nev, tipus
FROM suti INNER JOIN tartalom ON suti.id = tartalom.sutiid
WHERE mentes = "L" AND (tipus = "pite" OR tipus = "tortaszelet");
```

### 5. Jelentés a torták árlistájáról
```sql
SELECT egyseg, nev, ertek
FROM suti INNER JOIN ar ON suti.id = ar.sutiid
WHERE tipus = "torta"
ORDER BY egyseg, nev ;
```

### 6. Glutén- és tojásmentes sütemények
```sql
SELECT nev, tipus
FROM suti INNER JOIN tartalom ON suti.id = tartalom.sutiid
WHERE mentes = "G" OR mentes = "To"
GROUP BY nev, tipus
HAVING COUNT(*) = 2;
```
# [Akadémikusok érettségi feladatsor](https://github.com/MolnAtt/SQL/blob/main/feladatsorok/erettsegi/akademikusok/Akad%C3%A9mikusok%20F/Akad%C3%A9mikusok.pdf)

### 2. Élő akadémikusok ábécé sorrendben
```sql
SELECT *
FROM tag
WHERE elhunyt IS NULL
ORDER BY nev;
```

### 3. Nem(/nem csak) magyar identitású akadémikusok rendes vagy levelező taggá választásának dátuma
```sql
SELECT nev, identitas, tipus, ev
FROM tagsag INNER JOIN tag ON tagsag.tagid = tag.id
WHERE identitas IS NOT NULL AND (tipus = "r" OR tipus = "l")
ORDER BY ev;
```

### 4. Első taggá választás dátuma
```sql
SELECT tagid, nev, MIN(ev)
FROM tagsag INNER JOIN tag ON tagsag.tagid = tag.id
GROUP BY tagid, nev;
```

### 5. Nők aránya
```sql
SELECT ROUND(COUNT(IIF(nem = "n", 1, NULL))/COUNT(*), 2)&" %"
FROM tag;
```

### 6. Átlagosan eltelt idő a levelező és rendes taggá választás között
```sql
SELECT ROUND(SUM(limbo)/COUNT(limbo), 2) as atlagido
FROM (SELECT tagid, MAX(ev) - MIN(ev) AS limbo
FROM tagsag
WHERE tagid IN (SELECT tagid FROM tagsag WHERE tipus = "l")
GROUP BY tagid
HAVING COUNT(*) = 2);
```

### 7. Akadémia tiszteletbeli tagjai Teller Ede teljes tagsági ideje alatt
```sql
SELECT nev, ev, elhunyt
FROM tag, tagsag
WHERE tag.id=tagid
AND ev<=(SELECT ev FROM tag INNER JOIN tagsag ON tag.id = tagsag.tagid WHERE nev = "Teller Ede" )
AND (elhunyt>=(SELECT elhunyt FROM tag INNER JOIN tagsag ON tag.id = tagsag.tagid WHERE nev = "Teller Ede") OR NULL )
AND tipus='t'; 
```

### 8. Jelentés a XX. századi rendes tagokról
```sql
SELECT ev, nev, szuletett&" - "&elhunyt as elt
FROM tag INNER JOIN tagsag ON tag.id = tagsag.tagid
WHERE 1901 <= ev AND ev <= 2000 AND tipus = "r"
ORDER BY ev, nev;
```
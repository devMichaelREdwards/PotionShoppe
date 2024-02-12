INSERT INTO "Effect" (
        "Name",
        "Value",
        "Duration",
        "Description"
    )
VALUES ('Minor Health', 25, 0, 'Regens {value} health'),
    ('Major Health', 100, 0, 'Regens {value} health'),
    ('Minor Mana', 25, 0, 'Regens {value} mana'),
    ('Major Mana', 100, 0, 'Regens {value} mana'),
    (
        'Defense',
        50,
        10,
        'Increases defense by {value} for {duration} minutes'
    ),
    (
        'Acid Protection',
        0,
        10,
        'Grants Acid Protection for {duration} minutes'
    );
INSERT INTO "Ingredient" (
        "Name",
        "Description",
        "Price",
        "Cost",
        "CurrentStock",
        "Image",
        "EffectId",
        "IngredientCategoryId"
    )
VALUES (
        'Test Ingredient',
        'Bla bla bla',
        0,
        0,
        0,
        'Test',
        1,
        4
    ),
    ('Mana Wing', '', 50, 20, 10, '', 4, 3),
    ('King''s Crown', '', 1000, 700, 2, '', 5, 5),
    ('Elf''s Ear', '', 50, 30, 100, '', 6, 2);
INSERT INTO "Potion" (
        "Name",
        "Description",
        "Price",
        "Cost",
        "CurrentStock",
        "Image",
        "EmployeeId"
    )
VALUES ('Potion Of Health', '', 0, 0, 5, '', 1),
    ('Mushroom Mind', '', 0, 0, 5, '', 1),
    ('Wizard''s Rest', '', 0, 0, 5, '', 1),
    ('Anti-Acid Coating', '', 0, 0, 5, '', 1),
    ('Potion Of The Golem', '', 0, 0, 5, '', 1);
INSERT INTO "PotionEffect" ("PotionId", "EffectId")
VALUES (1, 2),
    (2, 4),
    (3, 4),
    (3, 5),
    (4, 6),
    (5, 5);

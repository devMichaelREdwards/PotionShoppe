INSERT INTO "Effect" (
        "EffectId",
        "Name",
        "Value",
        "Duration",
        "Description"
    )
VALUES (1, 'Minor Health', 25, 0, 'Regens {0} health'),
    (2, 'Major Health', 100, 0, 'Regens {0} health'),
    (3, 'Minor Mana', 25, 0, 'Regens {0} mana'),
    (4, 'Major Mana', 100, 0, 'Regens {0} mana'),
    (
        5,
        'Defense',
        50,
        10,
        'Increases defense by {0} for {1} minutes'
    ),
    (
        6,
        'Acid Protection',
        0,
        10,
        'Grants Acid Protection for {1} minutes'
    );
INSERT INTO "Ingredient" (
        "IngredientId",
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
        1,
        'Test Ingredient',
        'Bla bla bla',
        0,
        0,
        0,
        'Test',
        1,
        4
    ),
    (2, 'Mana Wing', '', 50, 20, 10, '', 4, 3),
    (3, 'King''s Crown', '', 1000, 700, 2, '', 5, 5),
    (4, 'Elf''s Ear', '', 50, 30, 100, '', 6, 2);
INSERT INTO "Potion" (
        "PotionId",
        "Name",
        "Description",
        "Price",
        "Cost",
        "CurrentStock",
        "Image",
        "EmployeeId"
    )
VALUES (1, 'Potion Of Health', '', 0, 0, 5, '', 1),
    (2, 'Mushroom Mind', '', 0, 0, 5, '', 1),
    (3, 'Wizard''s Rest', '', 0, 0, 5, '', 1),
    (4, 'Anti-Acid Coating', '', 0, 0, 5, '', 1),
    (5, 'Potion Of The Golem', '', 0, 0, 5, '', 1);
INSERT INTO "PotionEffect" ("PotionEffectId", "PotionId", "EffectId")
VALUES (1, 1, 2),
    (2, 2, 4),
    (3, 3, 4),
    (4, 3, 5),
    (5, 4, 6),
    (6, 5, 5);

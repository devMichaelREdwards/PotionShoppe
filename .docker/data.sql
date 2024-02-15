INSERT INTO "Effect" (
        "Name",
        "Value",
        "Duration",
        "Description",
        "Color"
    )
VALUES (
        'Minor Health',
        25,
        0,
        'Regens {value} health',
        'red'
    ),
    (
        'Major Health',
        100,
        0,
        'Regens {value} health',
        'red'
    ),
    (
        'Minor Mana',
        25,
        0,
        'Regens {value} mana',
        'lightblue'
    ),
    (
        'Major Mana',
        100,
        0,
        'Regens {value} mana',
        'darkblue'
    ),
    (
        'Defense',
        50,
        10,
        'Increases defense by {value} for {duration} minutes',
        'grey'
    ),
    (
        'Acid Protection',
        0,
        10,
        'Grants Acid Protection for {duration} minutes',
        'limegreen'
    ),
    (
        'Strength Boost',
        0,
        120,
        'Increases physical strength for {duration} seconds.',
        'Red'
    ),
    (
        'Invisibility',
        0,
        60,
        'Turns the user invisible for {duration} seconds.',
        'Purple'
    ),
    (
        'Wisdom Enhancement',
        0,
        180,
        'Enhances magical abilities for {duration} seconds.',
        'Gold'
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
VALUES ('Mana Wing', '', 50, 20, 10, '', 4, 3),
    ('King''s Crown', '', 1000, 700, 2, '', 5, 5),
    ('Elf''s Ear', '', 50, 30, 100, '', 6, 2),
    (
        'Mystic Mushroom',
        'A rare mushroom with magical properties.',
        10,
        5,
        50,
        'https://localhost:7211/api/Image/Mystic_Mushroom.png',
        9,
        1
    ),
    (
        'Moonlight Herb',
        'A herb bathed in the light of the moon.',
        8,
        4,
        75,
        'https://localhost:7211/api/Image/Moonlight_Herb.png',
        8,
        2
    ),
    (
        'Enchanted Butterfly Wing',
        'A butterfly wing with mystical energy.',
        15,
        8,
        30,
        'https://localhost:7211/api/Image/Enchanted_Butterfly_Wing.png',
        3,
        3
    ),
    (
        'Crystalized Earth Stone',
        'A stone infused with earth magic.',
        12,
        6,
        40,
        'https://localhost:7211/api/Image/Crystalized_Earth_Stone.png',
        5,
        4
    ),
    (
        'Sapphire Gem',
        'A precious gem with water affinity.',
        20,
        10,
        20,
        'https://localhost:7211/api/Image/Sapphire_Gem.png',
        8,
        5
    );
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
    ('Potion Of The Golem', '', 0, 0, 5, '', 1),
    (
        'Elixir of Vitality',
        'A potion that restores health and enhances strength.',
        30,
        15,
        20,
        'https://localhost:7211/api/Image/Elixir_of_Vitality.png',
        1
    ),
    (
        'Mana Crystal Brew',
        'Brewed from rare ingredients, replenishes mana.',
        25,
        12,
        25,
        'https://localhost:7211/api/Image/Mana_Crystal_Brew.png',
        1
    ),
    (
        'Phantom Draught',
        'Grants invisibility and enhances magical abilities.',
        40,
        20,
        15,
        'https://localhost:7211/api/Image/Phantom_Draught.png',
        1
    );
INSERT INTO "PotionEffect" ("PotionId", "EffectId")
VALUES (1, 2),
    (2, 4),
    (3, 4),
    (3, 5),
    (4, 6),
    (5, 5),
    (6, 7),
    (6, 9),
    (7, 8),
    (7, 4),
    (8, 8),
    (8, 9);

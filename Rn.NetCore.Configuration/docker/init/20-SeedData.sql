-- Seed simple test values
INSERT INTO `Configuration`
  (`ConfigType`, `ConfigCategory`, `ConfigKey`, `ConfigValue`)
VALUES
  ('string', 'Dev.TestValues', 'SampleString', 'String Value'),
  ('int', 'Dev.TestValues', 'SampleInt', '10'),
  ('bool', 'Dev.TestValues', 'SampleBool', 'true'),
  ('datetime', 'Dev.TestValues', 'SampleDateTime', '1987-03-27 00:00:00'),
  ('long', 'Dev.TestValues', 'SampleLong', '12345654321'),
  ('float', 'Dev.TestValues', 'SampleFloat', '10.2'),
  ('double', 'Dev.TestValues', 'SampleDouble', '102.22');


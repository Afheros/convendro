# Introduction #

Design and functionality questions, features and remarks.

## Import external presets ##
  * Import of presets are currently all added to the PresetsList. We should probably make a distinction of external apps presets and Convendro presets (Category? If necessary, add a new element to XML file).
  * Import of Videora: default extension is mp4. We should probably ask the user to set this before processing the preset file. Could go in the settings dialog. Wait, there is no settings dialog yet...
  * Other presets? Handbrake? (Handbrake uses own CLI, might be able to see what's going on internally).

## Plug-in structure ##
  * Planned at a later stage, need to map out which functions should be exposed. Need this direly.

## Threading and Queuing ##
  * Need real/better queuing

## Test Runs ##
  * Need to be able to monitor test runs (need to check out ffmpeg sources for text I can use as a reference. Basic logic is there)

## User interaction ##
  * Program should suggest features (now completely relies on user's knowledge of ffmpeg.

## Internationalization ##
  * No high priority at this stage.
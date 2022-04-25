## SIMPLE PLANE SCRAPPER

### Description

Takes Json input from target, reformats and outputs in CSV files.

Target: http://homeworktask.infare.lt/

Libraries used:

1. HttpClient
2. Newtonsoft
3. CsvHelper

### How to run it?

Run these commands:

1. `git clone https://github.com/Ma8chZU3SZBh6H/PlaneExtractor.git`
2. `cd PlaneExtractor`
3. `docker compose up`

Output will be placed in `\PlaneExtractor\build\cvs`

### Project structure with descriptions

| Class    | Description                               |
|----------|-------------------------------------------|
| Program  | Runs `Scrapper` with different parameters |
| Scrapper | Runs `Api`, `Refactor` and saves in cvs   |
| Api      | Fetches JSON                              |
| Refactor | Refactors JSON                            |

### Note for the instructors

The specific file that was requested in the homework is at `\PlaneExtractor\build\cvs\MAD_AUH.csv`

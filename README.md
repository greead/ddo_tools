## DDO Tools
These are a host of tools for the DDO MMO. I am working on these as a side project to help me to develop my skills and also to work with a game that I personally enjoy despite its many flaws.

### DDO News Scraper (Python web scraper)
#### Summary
This is a simple script that uses web scraping to grab the latest news from the DDO webpage and put it into a single JSON file for easy parsing. DDO also has weekly coupon codes, and this scraper also parses through the news pages and collects these coupon codes. This is done using a headless Selenium browser which is able to quickly collect all of the news cards and go to coupon pages individually.

Ideally, this data could be hosted for multiple purposes. The most obvious purposes to me are to have a Discord bot that is able to provide news updates in a channel or to integrate it with the Thieves' Tools DDO plugin (below) that I am developing so that one could get the latest coupon code with the click of a button for redemption purposes.

#### Relevant technologies
- Python
- Selenium
- Jupyter notebook
- JSON

#### Relevant skills
- Python programming
- Web scraping
- Data cleaning

### Thieves' Tools (DDO Dungeon Helper Plugin)
#### Summary
This is a plugin built for the Dungeon Helper plugin framework. It doesn't have a singular purpose, and instead is a collection of QoL tools. 

I am currently in a very experimental phase of development where I am exploring the Dungeon Helper SDK. I have many ideas for tools that I would like to implement into this plugin, but these features require a lot more research on my part as the SDK is not documented as much as I would prefer it to be. Overall, this has provided me a LOT of insight into the inner workings of the game's inner workings and is overall incredibly interesting.

#### Developed features
- Button to open a wiki page for the currently active quest

#### Wanted features
- Updates to the wiki button to open pages for hub areas as well
  - Required: Getting UI element properties or getting location information
- Combat trackers for damage, healing, and tanking
  - Required: Parsing combat log information or getting combat event properties
- Alert system for effects
  - Required: A Windows form that is not clickable and getting effect information from effect events or combat logs
- Loot table viewing
  - Required: Unsure/Needs research (may be able to get tables from the wiki or directly from the game data)
- Crafting helper
  - Required: Integration of wiki tables into the tool
- Duplicate effect finder
  - Required: Parsing through inventory and active effects to find duplicates

#### Current experimentation
- I am currently experimenting with the event provider for combat tracking.

#### Relevant technologies
- C#
- .NET
- Windows Forms
- Visual Studio 2022

#### Relevant skills
- C# programming
- UI programming
- Working with niche SDKs
- Exploration and experimentation of poorly documented and niche systems

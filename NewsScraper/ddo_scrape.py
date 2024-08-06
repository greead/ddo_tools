## Imports
from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.chrome.options import Options
from selenium.webdriver.remote.webelement import WebElement
import json


## Constants
URL = "https://www.ddo.com/home/news"
NEWS_CARD_CLASS = "news-link"


## Options setup
browser_options = Options()
browser_options.add_argument("--headless=new")


## Get driver function
def get_open_driver(url: str = URL, options: Options = browser_options) -> webdriver.Chrome:
    driver = webdriver.Chrome(options=options)
    driver.get(url)
    return driver


## Get news cards function
def get_news_cards(driver: webdriver.Chrome, element_class: str = NEWS_CARD_CLASS) -> list[WebElement]:
    card_elements = driver.find_elements(By.CLASS_NAME, element_class)
    return card_elements


## Get cards list function
def get_cards_list(card_elements: list[WebElement]) -> list[dict[str, str]]:
    cards: list[dict[str, str]] = []

    for card_element in card_elements:
        card = {
            "link":card_element.get_attribute("href"),
            "title":card_element.find_element("class name", "news-title").text,
            "full_summary":card_element.find_element("class name", "news-summary").get_attribute("title"),
            "short_summary":card_element.find_element("class name", "news-summary").text,
            "date":card_element.find_element("class name", "news-date").text.split(" | ")[0],
            "coupon":None
        }

        cards.append(card)

    return cards


## Get coupon codes for cards function
def update_coupons(cards: list[dict[str, str]], driver: webdriver.Chrome) -> None:
    for card in cards:
        if "sales:" in card["title"].lower():
            driver.get(card["link"])
            
            body = driver.find_element("class name", "article-body")
            sales_text_lines = body.text.splitlines()

            coupon = {}

            line: str
            for i, line in enumerate(sales_text_lines):
                l_line = line.lower().strip()
                if "weekly" in l_line and "coupon" in l_line:
                    coupon["item"] = sales_text_lines[i+1].strip()
                    coupon["code"] = sales_text_lines[i+2].strip().split(": ")[1]
                    coupon["exp"] = sales_text_lines[i+3].rstrip("!").lstrip("Now through ")

            card["coupon"] = coupon
  

## Get and save data as json
def get_save_json(filename: str = "ddo_cards.json"):
    driver = get_open_driver()
    news_cards = get_news_cards(driver)
    cards_list = get_cards_list(news_cards)
    update_coupons(cards_list, driver)
    with open(filename, "w") as file:
        json.dump(cards_list, file, indent=4)


## Get updated list of news cards
def get_updated_list() -> list[dict[str, str]]:
    driver = get_open_driver()
    news_cards = get_news_cards(driver)
    cards_list = get_cards_list(news_cards)
    update_coupons(cards_list, driver)
    return cards_list


if __name__ == "__main__":
    get_save_json()
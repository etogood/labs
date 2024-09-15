import pandas as pd
from tqdm import tqdm
import stanza
import csv
import nltk
from nltk.tokenize import word_tokenize, sent_tokenize

df = pd.read_excel('fill_info.xlsx')
nltk.download('punkt')

full_corpus = df["TEXT"].values
sentences = [sent for corp in full_corpus for sent in sent_tokenize(corp, language="russian")]
long_sents = [i for i in sentences if len(i) > 30]

nlp = stanza.Pipeline(lang='ru',
processors='tokenize,pos,lemma,ner,depparse')


triplets = []
for s in tqdm(long_sents):
    doc = nlp(s)
    for sent in doc.sentences:
        entities = [ent.text for ent in sent.ents]
        res_d = dict()
        temp_d = dict()
        for word in sent.words:
            temp_d[word.text] = {"head": sent.words[word.head-1].text, "dep": word.deprel, "id": word.id}
        for k in temp_d.keys():
            nmod_1 = ""
            nmod_2 = ""
            if (temp_d[k]["dep"] in ["nsubj", "nsubj:pass"]) & (k in entities):
                res_d[k] = {"head": temp_d[k]["head"]}
                
                for k_0 in temp_d.keys():
                    if (temp_d[k_0]["dep"] in ["obj", "obl"]) &\
                       (temp_d[k_0]["head"] == res_d[k]["head"]) &\
                        (temp_d[k_0]["id"] > temp_d[res_d[k]["head"]]["id"]):
                        res_d[k]["obj"] = k_0
                        break
                
                for k_1 in temp_d.keys():
                    if (temp_d[k_1]["head"] == res_d[k]["head"]) & (k_1 == "не"):
                        res_d[k]["head"] = "не "+res_d[k]["head"]
                
                if "obj" in res_d[k].keys():
                    for k_4 in temp_d.keys():
                        if (temp_d[k_4]["dep"] =="nmod") &\
                           (temp_d[k_4]["head"] == res_d[k]["obj"]):
                            nmod_1 = k_4
                            break
                            
                    for k_5 in temp_d.keys():
                        if (temp_d[k_5]["dep"] =="nummod") &\
                           (temp_d[k_5]["head"] == nmod_1):
                            nmod_2 = k_5
                            break
                    res_d[k]["obj"] = res_d[k]["obj"]+" "+nmod_2+" "+nmod_1

        if len(res_d) > 0:
            triplets.append([s, res_d])

clear_triplets = []
for tr in triplets:
    for k in tr[1].keys():
        if "obj" in tr[1][k].keys():
            clear_triplets.append([tr[0], k, tr[1][k]['head'], tr[1][k]['obj']])

file_path = 'triplets.csv'
with open(file_path, mode='w', newline='', encoding='utf-8') as file:
    writer = csv.writer(file)
    writer.writerow(["Source", "Target", "Type"])
    for tr in clear_triplets:
        writer.writerow([tr[0], tr[1], "directed"])
        writer.writerow([tr[1], tr[2], "directed"])

print(f"CSV файл успешно создан: {file_path}")

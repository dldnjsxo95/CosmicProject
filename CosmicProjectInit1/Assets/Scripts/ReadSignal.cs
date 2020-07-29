using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadSignal : MonoBehaviour
{
	public List<Spawn> spawnList;
	public GameObject spawnPoint60;
	public GameObject spawnPoint72;
	public float boxDelayTime;
	int spawnIndex;
	float currentDelayTime;


	private void Start()
	{
		spawnList = new List<Spawn>();
		ReadSpawnFile();
	}

	void ReadSpawnFile()
	{
		// 변수 초기화
		spawnList.Clear();
		spawnIndex = 0;

		// 리스폰 파일 읽기
		TextAsset textFile = Resources.Load("NeverBeLikeU") as TextAsset;
		StringReader stringReader = new StringReader(textFile.text);

		while (stringReader != null)
		{
			string line = stringReader.ReadLine();
			if (line == null)
				break;

			// 리스폰 데이터 생성
			Spawn spawnData = new Spawn();
			spawnData.delay = float.Parse(line.Split(',')[0]) / 1000; // 1. 시간 판단
			spawnData.OnOff = line.Split(',')[1];// 3. on off 변경
			spawnData.channel = int.Parse(line.Split(',')[2]);
			spawnData.location = int.Parse(line.Split(',')[3]);// 2. 60,72 판단
			spawnData.velocity = int.Parse(line.Split(',')[4]);
			spawnList.Add(spawnData);
		}

		//텍스트 파일 닫기
		stringReader.Close();

	}

	private void Update()
	{
		currentDelayTime += (1 - 0.04f) * Time.deltaTime; // 스폰 시간 증가

		if (currentDelayTime > spawnList[spawnIndex].delay + boxDelayTime)
		{
			print(currentDelayTime);
			boxDelayTime += 0;

			SpawnManage();
		}
	}

	void SpawnManage()
	{
		int setSpawn = 0;

		switch (spawnList[spawnIndex].OnOff)
		{
			case "On":
				setSpawn = 1;
				break;
			case "Off":
				setSpawn = 2;
				break;
		}


		if (spawnList[spawnIndex].location == 60 && spawnPoint60 != null)
		{
			if (setSpawn == 1) spawnPoint60.SetActive(true);
			if (setSpawn == 2) spawnPoint60.SetActive(false);
		}


		if (spawnList[spawnIndex].location == 72 && spawnPoint60 != null)
		{
			if (setSpawn == 1) spawnPoint72.SetActive(true);
			if (setSpawn == 2) spawnPoint72.SetActive(false);
		}

		spawnIndex++;

	}

}

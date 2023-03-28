namespace code.c_sharp_code.sort; 

public class Merge {
    public static void Sort(int[] array) {
        if (array.Length < 2) {
            return;
        }

        int middle = array.Length / 2;
        int[] left = new int[middle];
        int[] right = new int[array.Length - middle];

        for (int i = 0; i < middle; i++) {
            left[i] = array[i];
        }

        for (int i = middle; i < array.Length; i++) {
            right[i - middle] = array[i];
        }

        Sort(left);
        Sort(right);
        MergeSort(array, left, right);
    }

    private static void MergeSort(int[] array, int[] left, int[] right) {
        int i = 0;
        int j = 0;
        int k = 0;

        while (i < left.Length && j < right.Length) {
            if (left[i] <= right[j]) {
                array[k] = left[i];
                i++;
            } else {
                array[k] = right[j];
                j++;
            }

            k++;
        }

        while (i < left.Length) {
            array[k] = left[i];
            i++;
            k++;
        }

        while (j < right.Length) {
            array[k] = right[j];
            j++;
            k++;
        }
    }
}
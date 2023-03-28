namespace code.c_sharp_code.sort;

public class Quick {
    public static void Sort(int[] array) {
        Sort(array, 0, array.Length - 1);
    }

    private static void Sort(int[] array, int left, int right) {
        if (left >= right) {
            return;
        }

        int pivot = array[(left + right) / 2];
        int index = Partition(array, left, right, pivot);
        Sort(array, left, index - 1);
        Sort(array, index, right);
    }

    private static int Partition(int[] array, int left, int right, int pivot) {
        while (left <= right) {
            while (array[left] < pivot) {
                left++;
            }

            while (array[right] > pivot) {
                right--;
            }

            if (left <= right) {
                (array[left], array[right]) = (array[right], array[left]);
                left++;
                right--;
            }
        }

        return left;
    }
}